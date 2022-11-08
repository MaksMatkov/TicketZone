import { SelectionModel } from '@angular/cdk/collections';
import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
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
  displayedColumns: string[] = ['select', 'number', 'seatsCount'];
  dataSource! : MatTableDataSource<Room>;
  selection = new SelectionModel<Room>(true, []);

  constructor(public _rs : RoomService) { }

  ngOnInit(): void {
    this._rs.GetAll().subscribe(data =>{
      this.dataSource = new MatTableDataSource<Room>(data);
    });
  }

  reload(){
    this._rs.GetAll().subscribe(data =>{
      this.dataSource = new MatTableDataSource<Room>(data);
      this.selection.clear();
    });
  }

  onDeleteClick(id : number){
    if(confirm("Are you sure?"))
      this._rs.Delete(id).subscribe((data) => {this.reload()})
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
