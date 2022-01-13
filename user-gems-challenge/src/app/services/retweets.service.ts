import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Retweet } from 'src/domain/retweets';

@Injectable({
  providedIn: 'root'
})
export class RetweetService {
  apiURL: string = 'http://localhost:35681/Retweet';

  constructor(private httpClient: HttpClient) {};
  public createRetweet(retweet: Retweet){
    return this.httpClient.post(`${this.apiURL}`,retweet);
  }
  public deleteRetweet(id){ 
    return this.httpClient.delete(`${this.apiURL}/${id}`);
  }
}
