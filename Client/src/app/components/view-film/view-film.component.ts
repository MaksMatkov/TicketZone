import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Film } from 'src/app/common/models/film/Film';
import { FilmService } from 'src/app/common/services/filmService/film.service';
import { ViewingTimeService } from 'src/app/common/services/ViewingTimeService/viewing-time.service';
import { ViewingTime } from './../../common/models/viewingTimes/ViewingTime';
import { TicketOrderService } from './../../common/services/ticketOrderService/ticket-order.service';
import { AddTicketOrder } from './../../common/models/order/AddTicketOrder';
import { AuthService } from 'src/app/common/services/authService/auth.service';
import { Role } from 'src/app/common/enums/Role';


@Component({
  selector: 'app-view-film',
  templateUrl: './view-film.component.html',
  styleUrls: ['./view-film.component.scss']
})
export class ViewFilmComponent implements OnInit {
  
  filmId = 0
  film! : Film;
  dateTime!: Date | null;
  selectedView! : ViewingTime;
  showMoreInfo = false;
  disabledOrderBtn = false;

  constructor(public route: ActivatedRoute, public _fs :FilmService, public _vts :ViewingTimeService, public _os : TicketOrderService, private router: Router,public _as: AuthService) { }

  ngOnInit(): void {
     
    this.route.params.subscribe(params => {
      this.filmId = params['id'];
      if(this.filmId){
        this._fs.GetById(this.filmId).subscribe(data => {
          this.bindData(data);
        }, err => this.router.navigate(['/']))
      }
    });
  }

  get isNotHaveAnyShow(){
    return !this.selectedView && (!this.film || !this.film.viewingTimes || this.film.viewingTimes.length == 0);
  }

  bindData(data : Film){
    this.film = data;
    if(this._as.currentUserValue && this._as.currentUserValue.role == Role.Admin)
      this.disabledOrderBtn = true; 
  } 

  selectView(id : number){
    if(id > 0){
      this._vts.GetById(id).subscribe(data => {this.selectedView = data; this.showMoreInfo = true;});
    }
  }

  backClick(){
    this.selectedView = new ViewingTime(); 
    this.showMoreInfo = false;
  }

  madeOrder(){
    if(this._as.currentUserValue && this._as.currentUserValue.role == Role.User){
      if(confirm("Are you sure?")){
        var order = new AddTicketOrder();
        order.FilmViewingTimeId = this.selectedView.id;
        this._os.Save(order).subscribe(data => {alert("Done!"); this.selectView(this.selectedView.id)})
      }
    }
    else{
      alert("Please Log In!")
      this.router.navigate(['/login'])
    }
  }

  

}
