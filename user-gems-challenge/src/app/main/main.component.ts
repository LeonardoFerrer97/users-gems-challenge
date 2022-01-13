import { Component, OnInit } from '@angular/core';
import { MatSpinnerComponent } from 'src/app/mat-spinner/mat-spinner.component';
import { Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import { Tweet } from 'src/domain/tweet';
import { User } from 'src/domain/user';
import { UserService } from 'src/app/services/user.service'
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { TweetService } from '../services/tweets.service';
import { FormBuilder } from '@angular/forms';
import { RetweetService } from '../services/retweets.service';
import { Retweet } from 'src/domain/retweets';
@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  tweets: Array<Tweet>;
  tweetsAux: Array<Tweet>;
  image: string;
  users: any[];
  tweetForm = this.formBuilder.group({
    tweet: '',
    image: ''
  });
  searchForm = this.formBuilder.group({
    search: ''
  });
  constructor(public router: Router,
    public tweetService: TweetService,
    public userService: UserService,
    public dialog: MatDialog,
    private formBuilder: FormBuilder,
    public retweetService: RetweetService) { }

  goToProfile() {
    this.router.navigate(["/Profile"], { state: { user: JSON.parse(localStorage.getItem('user')) } })
  }

  toProfile(tweet) {
    let user = { id: tweet.userId, name: tweet.userName };
    this.router.navigate(["/Profile"], { state: { user: user } })
  }

  toUserProfile(name){
    this.userService.getUserByName(name).subscribe((user)=>{
      this.router.navigate(["/Profile"], { state: { user: user[0] } })
    })
  }

  ngOnInit(): void {
    this.getTweets();
    this.createTweetForm();
    this.getUsers();
  }

  getTweets(): void {
    var user = localStorage.getItem('user')
    let dialogRef: MatDialogRef<MatSpinnerComponent> = this.dialog.open(MatSpinnerComponent, {
      panelClass: 'transparent',
      disableClose: true
    });
    this.tweetService.getTweets(JSON.parse(user).id).subscribe((tweet) => {
      this.tweets = tweet;
      this.tweetsAux = tweet;
      dialogRef.close();
    });
  }

  getUsers(){
    this.userService.getUsers().subscribe((users)=>{
      this.users = users;
    })
  }

  search(search) {
    this.tweets = this.tweetsAux;
    this.tweets = this.tweets.filter((x) => x.description.toLowerCase().includes(search.toLowerCase()))
  }


  createTweetForm() {
    this.tweetForm = new FormGroup({
      tweet: new FormControl("")
    })
  }

  onAddImage(event) {
    const file = event.target.files[0];
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
      this.image = reader.result.toString();
    };
  }

  createNewTweet() {
    let newTweet = new Tweet();

    newTweet.userId = JSON.parse(localStorage.getItem("user")).id
    newTweet.description = this.tweetForm.controls['tweet'].value
    newTweet.image = this.image
    newTweet.createdAt = new Date();
    let dialogRef: MatDialogRef<MatSpinnerComponent> = this.dialog.open(MatSpinnerComponent, {
      panelClass: 'transparent',
      disableClose: true
    });
    this.tweetService.createTweet(newTweet).subscribe((tweet) => {
      dialogRef.close(); 
      this.getTweets();

    }, error => { dialogRef.close(); })
  }

  retweetTweet(tweet) {
    let retweet = new Retweet();
    retweet.createdAt = new Date();
    retweet.tweetId = tweet.id;
    retweet.userId = JSON.parse(localStorage.getItem("user")).id
    let dialogRef: MatDialogRef<MatSpinnerComponent> = this.dialog.open(MatSpinnerComponent, {
      panelClass: 'transparent',
      disableClose: true
    });
    this.retweetService.createRetweet(retweet).subscribe(() => {
      dialogRef.close();
      this.getTweets();
    }, error => { dialogRef.close(); })
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
