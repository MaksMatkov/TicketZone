import { SelectionModel } from '@angular/cdk/collections';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { User } from 'src/app/common/models/user/User';
import { UserService } from 'src/app/common/services/UserService/user.service';
import { AdminMenuState } from 'src/app/common/states/adminMenuState';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {

  usersList! : Observable<User[]>

  displayedColumns: string[] = ['select', 'name', 'email', 'lastVisited', 'status'];
  dataSource! : MatTableDataSource<User>;
  selection = new SelectionModel<User>(true, []);

  constructor(public _us : UserService,
              private _snackBar: MatSnackBar,
              public _at : AdminMenuState) { }

  ngOnInit(): void {
    this._us.GetAll().subscribe(data => this.dataSource = new MatTableDataSource<User>(data));
  }

  reload(){
    this._us.GetAll().subscribe(data => {
      this.dataSource = new MatTableDataSource<User>(data);
      this.selection.clear();
      this._at.needApproveUsersCount = data.filter(el => !el.isApproved).length;
    });
  }

  approve(id:number | any){
    if(id)
      this._us.Approve(id).subscribe(res => {this._snackBar.open('User was approved!', 'Ok'); this.reload()})
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
