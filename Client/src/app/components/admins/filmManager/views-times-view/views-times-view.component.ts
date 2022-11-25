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
import { animate, state, style, transition, trigger } from '@angular/animations';
import { ActivatedRoute } from '@angular/router';
import { SelectionModel } from '@angular/cdk/collections';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-views-times-view',
  templateUrl: './views-times-view.component.html',
  styleUrls: ['./views-times-view.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class ViewsTimesViewComponent implements OnInit {

  @Input() filmId = 0;
  vTimes! : Observable<ViewingTimeLite[]>;
  cVTime! : ViewingTime;
  isOpenEditBlock = false;
  Rooms! : Observable<Room[]>;
  roomSelectedValue = 0;
  minDate = Date.now();

  dataSource! : MatTableDataSource<ViewingTimeLite>;
  displayedColumns = ['select', 'date', 'roomNumber', 'ordersCount', 'seatsCount'];
  expandedElement!: ViewingTimeLite | null;
  selection = new SelectionModel<ViewingTimeLite>(true, []);

  public vtForm: FormGroup = new FormGroup({
    date: new FormControl('', [Validators.required]),
    room: new FormControl('', Validators.required)
  });

  get dateControl() { return this.vtForm.controls['date'] as FormControl; }

  get roomControl() { return this.vtForm.controls['room'] as FormControl; }

  constructor(public _fs : FilmService, 
              public _vts : ViewingTimeService, 
              public _rs : RoomService, 
              public route : ActivatedRoute,
              private _snackBar: MatSnackBar ) { }

  reload(){
    this._fs.GetViewingTimes(this.filmId).subscribe(data => {
      
      this.dataSource = new MatTableDataSource<ViewingTimeLite>(data);
      this.isOpenEditBlock =false;
      this.selection.clear();
    });
  }

  submit(){

    if(!this.vtForm.valid)
      return;
    let addVt = new AddViewingTime();
    if(this.cVTime && this.cVTime.id > 0){
      addVt.date = this.dateControl.value as Date;
      addVt.roomId = this.roomControl.value;
      addVt.filmId = this.filmId;
      this._vts.Put(addVt, this.cVTime.id).subscribe(res => {this._snackBar.open('Done!', 'Ok'); this.reload(); });
    }
    else{
      addVt.date = this.dateControl.value as Date;
      addVt.roomId = this.roomControl.value;
      addVt.filmId = this.filmId;
      this._vts.Save(addVt).subscribe(res => {this._snackBar.open('Done!', 'Ok'); this.reload(); });
    }
  }

  initData(_vtId : number){
    this.Rooms = this._rs.GetAll();

    if(_vtId > 0){
      this._vts.GetById(_vtId).subscribe(data => {
        this.cVTime = data;
        this.dateControl.reset(data.date);
        this.roomControl.reset(data.roomId);
        this.isOpenEditBlock = true;
      })
    }
    else{
      this.dateControl.reset("");
      this.roomControl.reset("");
      this.isOpenEditBlock = true;
      this.cVTime = new ViewingTime();
    }
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.filmId = params['id'];
      if(this.filmId){
        this.reload();
      }
    });
  }

  onDeleteClick(id : number){
    if(confirm("Are you sure?")){
      this.isOpenEditBlock = false;
      this._vts.Delete(id).subscribe((data) => { this._snackBar.open('Done!', 'Ok'); this.reload()})
    }
  }

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ?
        this.selection.clear() :
        this.dataSource.data.forEach(row => this.selection.select(row));
  }

}
