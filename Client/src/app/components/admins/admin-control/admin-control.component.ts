import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from 'src/app/common/services/UserService/user.service';
import { AdminMenuState } from 'src/app/common/states/adminMenuState';
import { LogService } from './../../../common/services/log.service';

@Component({
  selector: 'app-admin-control',
  templateUrl: './admin-control.component.html',
  styleUrls: ['./admin-control.component.scss']
})
export class AdminControlComponent implements OnInit {

  constructor(public router : Router, 
    public _us : UserService,
    public _at : AdminMenuState,
    public _ls : LogService) { }
    get notApprovedUsersCount(){
      return this._at.needApproveUsersCount;
    }
    
  ngOnInit(): void {
    this._us.GetNotApprovedCount().subscribe(count => {
      this._at.needApproveUsersCount = count;
    });
  }
  redirect(path : string){
    this.router.navigate([path]);
  }
  downloadLog(){
    this._ls.Download();
  }

}
