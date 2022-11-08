import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-control',
  templateUrl: './admin-control.component.html',
  styleUrls: ['./admin-control.component.scss']
})
export class AdminControlComponent implements OnInit {

  constructor(public router : Router) { }

  ngOnInit(): void {
  }
  redirect(path : string){
    this.router.navigate([path]);
  }

}
