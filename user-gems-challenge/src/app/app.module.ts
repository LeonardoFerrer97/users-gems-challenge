import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatExpansionModule} from '@angular/material/expansion';
import { HttpClientModule } from '@angular/common/http';
import { UserService } from './services/user.service';    
import { AuthGuard, AuthModule, AuthService } from '@auth0/auth0-angular';
import { HomeComponent } from './home/home.component';
import {MatDialogModule} from '@angular/material/dialog';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from "@angular/material/input";
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';

import { MatSelectModule } from "@angular/material/select";
import { MatSpinnerComponent } from './mat-spinner/mat-spinner.component';
import { ProfileComponent } from './profile/profile.component';
import { MainComponent } from './main/main.component';
import { FollowingComponent } from './following/following.component';
import { FollowingService } from './services/following.service';
import { Retweet } from 'src/domain/retweets';
import { RetweetService } from './services/retweets.service';
import { TweetService } from './services/tweets.service';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProfileComponent,
    MainComponent,
    FollowingComponent,
    MatSpinnerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatIconModule,
    BrowserAnimationsModule,
    MatMenuModule,
    AuthModule.forRoot({
      domain: 'dev-d1olx9ru.auth0.com',
      clientId: 'wnK9bKI1imlksxrkvuyVUM8fQ1zlL6uu'
    }),HttpClientModule,ReactiveFormsModule,FormsModule,MatExpansionModule,MatDialogModule,MatInputModule,MatSelectModule,
    MatPaginatorModule,MatProgressSpinnerModule, FontAwesomeModule

  ],
  providers: [AuthService,UserService,FollowingService,RetweetService,TweetService,AuthGuard],
  bootstrap: [AppComponent],

  entryComponents: [
    MatSpinnerComponent 
  ]
})
export class AppModule { }
