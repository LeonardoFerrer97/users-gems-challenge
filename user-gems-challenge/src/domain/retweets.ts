import { Tweet } from "./tweet";

export class Retweet {

    id: string|undefined; 
    userId: string|undefined; 
    tweetId: string|undefined; 
    createdAt: Date|undefined; 
    tweet: Tweet | undefined
}
