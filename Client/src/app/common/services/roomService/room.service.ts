import { Injectable } from '@angular/core';
import { AddRoom } from '../../models/room/AddRoom';
import { Room } from '../../models/room/Room';
import { BaseRestService } from '../baseService/base-rest.service';
import { AuthDaSettings } from '../servicesEndpoints';

@Injectable({
  providedIn: 'root'
})
export class RoomService extends BaseRestService<Room, Room, AddRoom> {
  override endPoint =  AuthDaSettings.roomsEndpoint;
}
