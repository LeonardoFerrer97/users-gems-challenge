import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/domain/user';
import { UserService } from '../services/user.service';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  user = new User();
  isLogin=true;
  loginForm = this.formBuilder.group({
    email: '',
    password: ''
  });
  signUpForm = this.formBuilder.group({
    email: '',
    name: '',
    password: ''
  });
  constructor(public userService: UserService,public router: Router,
    private formBuilder: FormBuilder){
      if (localStorage.getItem('user')) {
        // logged in so return true
        router.navigate(["/Main"])
    }

  }
  login(){
    this.user.Email = this.loginForm.controls['email'].value
    this.user.Password = this.loginForm.controls['password'].value
    this.userService.login(this.user).subscribe((user)=>{
      localStorage.setItem('user', JSON.stringify(user));
      this.router.navigate(["/Main"]);
    }); 
  }
  signUp(){
    this.user.Email = this.signUpForm.controls['email'].value
    this.user.Password = this.signUpForm.controls['password'].value
    this.user.Name = this.signUpForm.controls['name'].value
    this.userService.signUp(this.user).subscribe(()=>{
      this.userService.getUserByName(this.user.Name).subscribe((user)=>{
        localStorage.setItem('user', JSON.stringify(user));
      })
      this.router.navigate(["/Main"]);
    }); 
  }

  switch(){
    this.isLogin = !this.isLogin
  }
  ngOnInit(): void {
  }

}
