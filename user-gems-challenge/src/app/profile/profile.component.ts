import { Component, OnInit } from '@angular/core';
import { MatSpinnerComponent } from 'src/app/mat-spinner/mat-spinner.component';

import { Router } from '@angular/router';
import { Tweet } from 'src/domain/tweet';
import { User } from 'src/domain/user';
import { UserService } from 'src/app/services/user.service'
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { TweetService } from '../services/tweets.service';
import { FormBuilder } from '@angular/forms';
import { RetweetService } from '../services/retweets.service';
import { FollowingService } from '../services/following.service';
import { Following } from 'src/domain/following';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  tweets: Array<Tweet>;
  tweetsAux: Array<Tweet>;
  loggedUser: any;
  user: any;
  image: string;
  usersSearch: User[];
  isToFollow:boolean;
  constructor(public router: Router, public tweetService: TweetService, 
    public userService: UserService, public dialog2: MatDialog,  public retweetService: RetweetService,
    private followingService: FollowingService) {
    this.user = this.router?.getCurrentNavigation()?.extras?.state?.user;
    this.loggedUser = JSON.parse(localStorage.getItem('user'));
  }
  ngOnInit(): void {
    this.getTweets();
    this.isSameProfile();
  }

  getTweets(): void {
    let dialogRef: MatDialogRef<MatSpinnerComponent> = this.dialog2.open(MatSpinnerComponent, {
      panelClass: 'transparent',
      disableClose: true
    });
    this.tweetService.getTweets(this.user.id).subscribe((tweet) => {
      this.tweets = tweet;
      this.tweetsAux = tweet;
      dialogRef.close();
    });
  }
  follow(){
    let following = new Following();
    following.userId = this.loggedUser.id;
    following.followingId = this.user.id
    this.followingService.createFollowing(following).subscribe(()=>{
      this.isToFollow = false;
    })
  }
  MainPage(){
    this.router.navigate(["/Main"])
  }
  isSameProfile(){
    if(this.user.name != this.loggedUser.name) {
      this.isToFollow =  true;
    }else{
      this.isToFollow = false;
    }
  }
  toProfile(tweet) {
    let user = new User();
    user.Id = tweet.userId;
    user.Name = tweet.userName;
  }

  menuOpen() {
    const overlay = document.querySelector(".overlay");
    overlay.classList.add("overlay--active");
  }
  menuClose() {
    const overlay = document.querySelector(".overlay");
    overlay.classList.remove("overlay--active");
  }

  logout() {
    localStorage.clear();
  }

}
