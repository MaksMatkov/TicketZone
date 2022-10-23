import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Status } from '../../enums/Status';
import { AddTicketOrder } from '../../models/order/AddTicketOrder';
import { TicketOrder } from '../../models/order/TicketOrder';
import { BaseRestService } from '../baseService/base-rest.service';
import { AuthDaSettings } from '../servicesEndpoints';

@Injectable({
  providedIn: 'root'
})
export class TicketOrderService extends BaseRestService<TicketOrder,TicketOrder,AddTicketOrder> {

  override endPoint =  AuthDaSettings.ticketOrderEndpoint;

  public GetMyOrders(): Observable<TicketOrder[]> {
    return this.http.get(this.apiUrl + this.endPoint + `/myOrders`).pipe(
      map(res => {
        return <TicketOrder[]>res;
      }));
  }

  public SetStatus(id : number, status : Status): Observable<any> {
    return this.http.post(this.apiUrl + this.endPoint + `/${id}/setStatus/${status}`, {}).pipe(
      map(res => {
        return res;
      }));
  }

  public Reject(id : number): Observable<any> {
    return this.http.post(this.apiUrl + this.endPoint + `/${id}/reject`, {}).pipe(
      map(res => {
        return res;
      }));
  }
  
}
