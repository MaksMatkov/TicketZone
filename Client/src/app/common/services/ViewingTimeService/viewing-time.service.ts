import { Injectable } from '@angular/core';
import { AddViewingTime } from '../../models/viewingTimes/AddViewingTime';
import { ViewingTime } from '../../models/viewingTimes/ViewingTime';
import { ViewingTimeLite } from '../../models/viewingTimes/ViewingTimeLite';
import { BaseRestService } from '../baseService/base-rest.service';
import { AuthDaSettings } from '../servicesEndpoints';

@Injectable({
  providedIn: 'root'
})
export class ViewingTimeService extends BaseRestService<ViewingTimeLite, ViewingTime, AddViewingTime> {
  override endPoint =  AuthDaSettings.viewingTimeEndpoint;
}
