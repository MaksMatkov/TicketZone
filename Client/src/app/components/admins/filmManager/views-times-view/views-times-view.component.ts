import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { ViewingTime } from 'src/app/common/models/viewingTimes/ViewingTime';
import { ViewingTimeLite } from 'src/app/common/models/viewingTimes/ViewingTimeLite';
import { FilmService } from 'src/app/common/services/filmService/film.service';
import { ViewingTimeService } from './../../../../common/services/ViewingTimeService/viewing-time.service';
import { RoomService } from './../../../../common/services/roomService/room.service';
import { Room } from 'src/app/common/models/room/Room';
import { AddViewingTime } from './../../../../common/models/viewingTimes/AddViewingTime';

@Component({
  selector: 'app-views-times-view',
  templateUrl: './views-times-view.component.html',
  styleUrls: ['./views-times-view.component.scss']
})
export class ViewsTimesViewComponent implements OnInit {

  @Input() filmId = 0;
  vTimes! : Observable<ViewingTimeLite[]>;
  cVTime! : ViewingTime;
  isOpenEditBlock = false;
  Rooms! : Observable<Room[]>;
  roomSelectedValue = 0;
  minDate = Date.now();

  public vtForm: FormGroup = new FormGroup({
    date: new FormControl('', [Validators.required]),
    room: new FormControl('', Validators.required)
  });

  get dateControl() { return this.vtForm.controls['date'] as FormControl; }

  get roomControl() { return this.vtForm.controls['room'] as FormControl; }

  constructor(public _fs : FilmService, public _vts : ViewingTimeService, public _rs : RoomService) { }

  reload(){
    this.vTimes = this._fs.GetViewingTimes(this.filmId);
  }

  submit(){

    if(!this.vtForm.valid)
    return;
    let addVt = new AddViewingTime();
    if(this.cVTime && this.cVTime.id > 0){
      addVt.Date = this.dateControl.value as Date;
      addVt.FK_Room = this.roomControl.value;
      addVt.FK_Film = this.filmId;
      this._vts.Put(addVt, this.cVTime.id).subscribe(res => {alert("Done"); this.reload();}, err => alert(err.message));
    }
    else{
      addVt.Date = this.dateControl.value as Date;
      addVt.FK_Room = this.roomControl.value;
      addVt.FK_Film = this.filmId;
      this._vts.Save(addVt).subscribe(res => {alert("Done"); this.reload();}, err => alert(err.message));
    }
  }

  initData(_vtId : number){
    this.Rooms = this._rs.GetAll();

    if(_vtId > 0){
      this._vts.GetById(_vtId).subscribe(data => {
        this.cVTime = data;
        console.log(data)
        this.dateControl.reset(data.date);
        this.roomControl.reset(data.roomId);
      //  this.roomSelectedValue = data.roomNumber;

        this.isOpenEditBlock = true;


      }, err => alert(err.message))
    }
    else{
      this.dateControl.reset("");
      this.roomControl.reset("");
  //    this.roomSelectedValue = 0;
      this.isOpenEditBlock = true;
      this.cVTime = new ViewingTime();
    }
  }

  ngOnInit(): void {
    this.vTimes = this._fs.GetViewingTimes(this.filmId);
  }

  onDeleteClick(id : number){
    if(confirm("Are you sure?")){
      this.isOpenEditBlock = false;
      this._vts.Delete(id).subscribe((data) => {this.reload()}, err => alert("Something went wrong!"))
    }
  }

}
