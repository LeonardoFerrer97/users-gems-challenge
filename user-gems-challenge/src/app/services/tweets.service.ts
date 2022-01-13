import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Tweet } from 'src/domain/tweet';

@Injectable({
  providedIn: 'root'
})
export class TweetService {

  apiURL: string = 'http://localhost:35681/Tweet';

  constructor(private httpClient: HttpClient) { };
  public createTweet(tweet: Tweet) {
    return this.httpClient.post<Tweet>(`${this.apiURL}`, tweet);
  }

  public updateTweet(tweet: Tweet) {
    return this.httpClient.put(`${this.apiURL}`, tweet);
  }

  public deleteTweet(tweet: Tweet) {
    return this.httpClient.delete(`${this.apiURL}`, { body: tweet });
  }

  public getTweetById(id: number) {
    return this.httpClient.get<Tweet[]>(`${this.apiURL}/${id}`);
  }

  public getTweets(id, isProfile = false) {
    return this.httpClient.get<Tweet[]>(`${this.apiURL}/User/${id}?isProfile${isProfile}`);
  }
}
