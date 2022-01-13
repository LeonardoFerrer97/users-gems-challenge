// app.routing-module.ts has the following contents

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './profile/profile.component';
import { AuthGuard } from './guards/AuthGuard';
import { MainComponent } from './main/main.component';
import { FollowingComponent } from './following/following.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'Profile',
    component: ProfileComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'Main',
    component: MainComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'following',
    component: FollowingComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'profilex',
    component: ProfileComponent,
    canActivate: [AuthGuard]
  }

];

@NgModule({

  imports: [
    RouterModule.forRoot(routes)
  ],

  exports: [
    RouterModule
  ],
})
export class AppRoutingModule { }
