import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AddRoom } from 'src/app/common/models/room/AddRoom';
import { Room } from 'src/app/common/models/room/Room';
import { RoomService } from './../../../../common/services/roomService/room.service';

@Component({
  selector: 'app-room-edit',
  templateUrl: './room-edit.component.html',
  styleUrls: ['./room-edit.component.scss']
})
export class RoomEditComponent implements OnInit {


  roomId = 0
  room! : Room;

  public roomForm: FormGroup = new FormGroup({
    number: new FormControl('', [Validators.required, Validators.min(1)]),
    count: new FormControl('', [Validators.required, Validators.min(1)])
  });

  get numberForm() {
    return this.roomForm.controls['number'] as FormControl;
  }

  get countForm() {
    return this.roomForm.controls['count'] as FormControl;
  }

  constructor(public route: ActivatedRoute, public _rs :RoomService, private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.roomId = params['id'];
      if(this.roomId){
        this._rs.GetById(this.roomId).subscribe(data => {
          this.room = data;
          this.initData();
        })
      }
    });
  }

  initData(){
    this.numberForm.reset(this.room.number);
    this.countForm.reset(this.room.seatsCount);
  }

  async submit(){
    let inputModel = new AddRoom();
    inputModel.number = this.numberForm.value;
    inputModel.seatsCount = this.countForm.value;

    if(this.room && this.room.id > 0){
      this._rs.Put(inputModel, this.room.id)
      .subscribe(data =>  this.router.navigate(['/admin/rooms']));
      
    }
    else {
      this._rs.Save(inputModel)
      .subscribe(data =>  this.router.navigate(['/admin/rooms']));
    }
  }

  errShow(errResponse: any){
    if(errResponse && errResponse.error && errResponse.error.errorMessage)
      alert(errResponse.error.errorMessage);
    else
      console.log(errResponse)
  }

}