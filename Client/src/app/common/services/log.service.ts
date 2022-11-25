import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from './baseService/base.service';
import { AuthDaSettings } from './servicesEndpoints';

@Injectable({
  providedIn: 'root'
})
export class LogService extends BaseService {
  endPoint = AuthDaSettings.logEndpoint;
  public Download(){
    window.open(this.apiUrl + this.endPoint + `/download`)
  }
}
