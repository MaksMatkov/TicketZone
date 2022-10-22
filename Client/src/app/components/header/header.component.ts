import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Role } from 'src/app/common/enums/Role';
import { AuthService } from 'src/app/common/services/authService/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(public _as: AuthService,  private router: Router) { }

  ngOnInit(): void {
  }


  clickHome(){
    if(this._as.currentUserValue && this._as.currentUserValue.role == Role.Admin)
      this.router.navigate(['/admin']);
    else
      this.router.navigate(['/']);
  }

  clickLogOut(){
    this._as.LogOut();
  }

  clickLogIn(){
    this.router.navigate(['/login']);
  }

}
