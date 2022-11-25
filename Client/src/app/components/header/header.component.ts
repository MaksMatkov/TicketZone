import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Role } from 'src/app/common/enums/Role';
import { AuthService } from 'src/app/common/services/authService/auth.service';
import { LoadingStateService } from 'src/app/common/services/loadingstateService/loading-state.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(public _as: AuthService,  private router: Router, public _loadS : LoadingStateService) { }

  ngOnInit(): void {
  }

  get role(){
    return Role;
  }

  clickHome(){
    // if(this._as.currentUserValue && this._as.currentUserValue.role == Role.Admin)
    //   this.router.navigate(['/admin']);
    // else
      this.router.navigate(['/']);
  }

  clickSettings(){
    this.router.navigate(['/admin']);
  }

  clickMain(){
    this.router.navigate(['/']);
  }

  clickLogOut(){
    this._as.LogOut();
  }

  clickMyAccount(){
    this.router.navigate(['/my-account']);
  }

  clickLogIn(){
    this.router.navigate(['/login']);
  }

}
