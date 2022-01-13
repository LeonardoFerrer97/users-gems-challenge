import { User } from "./user";

export class Following {
    Id: number|undefined; 
    userId: string|undefined; 
    followingId: string |undefined;
    Following: Array<User>| undefined;
}