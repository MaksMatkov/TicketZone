import { Injectable } from '@angular/core';
import { AddUser } from '../../models/user/AddUser';
import { User } from '../../models/user/User';
import { BaseRestService } from '../baseService/base-rest.service';
import { AuthDaSettings } from '../servicesEndpoints';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseRestService<User, User, AddUser> {

  override endPoint =  AuthDaSettings.usersEndpoint;


  public Approve(id : number) : Observable<any>{
    return this.http.post(this.apiUrl + this.endPoint + `/approve/${id}`, {}).pipe(
      map(res => res));
  }

  public Register(user : AddUser) : Observable<any>{
    return this.http.post(this.apiUrl + this.endPoint + `/register`, user).pipe(
      map(res => res));
  }

  public GetInfo() : Observable<User>{
    return this.http.get(this.apiUrl + this.endPoint + `/getInfo`).pipe(
      map(res => <User>res));
  }

  public GetNotApprovedCount() : Observable<number>{
    return this.http.get(this.apiUrl + this.endPoint + `/notApprovedCount`).pipe(
      map(res => <number>res));
  }
}
