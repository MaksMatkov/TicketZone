import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map, Observable } from 'rxjs';
import {LocalStorageHelper} from "src/app/common/helpers/localStorage/local-storage.helper"
import { tokenData } from '../../models/tokenData';
import { BaseService } from '../baseService/base.service';
import { AuthDaSettings } from '../servicesEndpoints';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService {

  constructor(public override http: HttpClient, private router : Router) {
    super(http);
  }

  public get currentUserValue(): tokenData {
    var tokenData = LocalStorageHelper.Get("jwt") as tokenData;
    
    return tokenData || undefined;
  }

  public Login(email : string, password: string): Observable<tokenData> {
    return this.http.get(this.apiUrl + AuthDaSettings.signInEndpointUrl + '?email=' + email + '&password=' + password)
      .pipe(map(res => {
        var StateData = <tokenData>res;
        LocalStorageHelper.Set<tokenData>("jwt", StateData);
        return <tokenData>res;
      }));
  }

  public LogOut() : void {
    localStorage.removeItem('jwt');
    this.router.navigate(['/']);
  }
}
