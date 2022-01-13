import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Following } from 'src/domain/following';

@Injectable({
  providedIn: 'root'
})
export class FollowingService {

  apiURL: string = 'http://localhost:35681/Following';
  constructor(private httpClient: HttpClient) {};
  public createFollowing(follow: Following){
    return this.httpClient.post(`${this.apiURL}`,follow);
  }

  public getFollowing(){
    return this.httpClient.get<Following[]>(`${this.apiURL}`);
  }

  public deleteFollowing(id){ 
    return this.httpClient.delete(`${this.apiURL}/${id}`);
  }
}
