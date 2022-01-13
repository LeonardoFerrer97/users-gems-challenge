import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';

import { Router } from '@angular/router';
import { MatSpinnerComponent } from 'src/app/mat-spinner/mat-spinner.component';
import { FollowingService } from '../services/following.service';
@Component({
  selector: 'app-following',
  templateUrl: './following.component.html',
  styleUrls: ['./following.component.css']
})
export class FollowingComponent implements OnInit {
  filtro:string;
  following:any[];
  followingAux:any[];
  chatsAux:any[];
  user:any;
  pages = null
  constructor(public router: Router,public followingService: FollowingService,public dialog: MatDialog,public dialogNewChat: MatDialog) {
    this.getChats(); 

    this.user = this.router?.getCurrentNavigation()?.extras?.state?.user;
    if(this.user ==undefined){
      this.router.navigate([""]);
    }    
  }

  ngOnInit(): void {
  }
  getChats(){
    let dialogRef: MatDialogRef<MatSpinnerComponent> = this.dialog.open(MatSpinnerComponent, {
      panelClass: 'transparent',
      disableClose: true
    });
    this.followingService.getFollowing().subscribe(following=>{
      this.following =following;
      this.followingAux = following
      dialogRef.close();
    },error=>{ dialogRef.close();});
  }
  onFiltro(event){
    this.followingAux = this.following;
    this.following = this.following.filter(item =>
      item.title.toLowerCase().includes(this.filtro.toLowerCase())
  ).splice(0,3);
  }
  clickOnFollowing(following){
    this.router.navigate(["profilex/"+following.Following_Id],{state:{following:following,user:this.user}});   
  }

  
  deleteFollowing(id){
    let dialogRef: MatDialogRef<MatSpinnerComponent> = this.dialog.open(MatSpinnerComponent, {
      panelClass: 'transparent',
      disableClose: true
    });
    this.followingService.deleteFollowing(id).subscribe(()=>{
      dialogRef.close();
      var index = this.following.map(function(item) {
        return item.Id
      }).indexOf(id);
    this.following.splice(index, 1);
    },error=>{  dialogRef.close();});
  };
  
}
