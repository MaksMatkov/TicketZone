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
}
