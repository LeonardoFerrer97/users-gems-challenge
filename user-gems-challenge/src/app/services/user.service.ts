import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../../domain/user';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  apiURL: string = 'http://localhost:35681/User';

  constructor(private httpClient: HttpClient) {};
  public login(user: User){
    return this.httpClient.post(`${this.apiURL}/login`,user);
  }
  public signUp(user: User){
    return this.httpClient.post(`${this.apiURL}`,user);
  }

public deleteUser(id: number){
  return this.httpClient.delete(`${this.apiURL}/${id}`);
}

public getUserById(id: number){
  return this.httpClient.get<User>(`${this.apiURL}/${id}`);
}

public getUserByName(name: string){
  return this.httpClient.get<User[]>(`${this.apiURL}/name/${name}`);
}
public getUsers(){
  return this.httpClient.get<User[]>(`${this.apiURL}`);
}
public getUserByEmail(email?: string){
  return this.httpClient.get<User>(`${this.apiURL}/email/${email}`);
}



}
