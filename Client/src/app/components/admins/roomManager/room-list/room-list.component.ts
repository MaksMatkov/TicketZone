import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AddRoom } from 'src/app/common/models/room/AddRoom';
import { Room } from 'src/app/common/models/room/Room';
import { RoomService } from 'src/app/common/services/roomService/room.service';

@Component({
  selector: 'app-room-list',
  templateUrl: './room-list.component.html',
  styleUrls: ['./room-list.component.scss']
})
export class RoomListComponent implements OnInit {

  roomList!: Observable<Room[]>;

  constructor(public _rs : RoomService) { }

  ngOnInit(): void {
    this.roomList = this._rs.GetAll();
  }

  reload(){
    this.roomList = this._rs.GetAll();
  }

  onDeleteClick(id : number){
    if(confirm("Are you sure?"))
      this._rs.Delete(id).subscribe((data) => {this.reload()}, err => alert("Something went wrong!"))
  }

  edit(room : Room){
    let newRoom = new AddRoom();
    let number = prompt("Input Room Number:", `${room.number}`)
    let seatsCount = prompt("Input Seats Count:", `${room.seatsCount}`)

    newRoom.Number = Number.parseInt(number || "0");
    newRoom.SeatsCount  = Number.parseInt(seatsCount || "0");

    this._rs.Put(newRoom, room.id).subscribe((data) => {this.reload()}, err => alert("Something went wrong!"))
  }

  addNew(){
    let newRoom = new AddRoom();
    let number = prompt("Input Room Number:")
    let seatsCount = prompt("Input Seats Count:")

    newRoom.Number = Number.parseInt(number || "0");
    newRoom.SeatsCount  = Number.parseInt(seatsCount || "0");

    this._rs.Save(newRoom).subscribe((data) => {this.reload()}, err => alert(err.message))
  }
}
