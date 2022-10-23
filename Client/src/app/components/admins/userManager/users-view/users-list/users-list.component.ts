import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/app/common/models/user/User';
import { UserService } from 'src/app/common/services/UserService/user.service';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {

  usersList! : Observable<User[]>

  constructor(public _us : UserService) { }

  ngOnInit(): void {
    this.usersList = this._us.GetAll();
  }

  reload(){
    this.usersList = this._us.GetAll();
  }

  approve(id:number){
    this._us.Approve(id).subscribe(res => {this.reload()}, err => alert("Something went wrong!"))
  }

}
