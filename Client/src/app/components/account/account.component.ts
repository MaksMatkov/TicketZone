import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/common/models/user/User';
import { UserService } from 'src/app/common/services/UserService/user.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {
  longText = '';
  user!: User;
  constructor(private _us : UserService) { }

  ngOnInit(): void {
    this._us.GetInfo().subscribe(data => {
      this.user = data;
    })
  }

}
