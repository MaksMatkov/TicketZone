import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Status } from 'src/app/common/enums/Status';
import { TicketOrder } from 'src/app/common/models/order/TicketOrder';
import { TicketOrderService } from 'src/app/common/services/ticketOrderService/ticket-order.service';

@Component({
  selector: 'app-orders-view',
  templateUrl: './orders-view.component.html',
  styleUrls: ['./orders-view.component.scss']
})
export class OrdersViewComponent implements OnInit {

  orderList!: Observable<TicketOrder[]>;
  constructor(public _os : TicketOrderService) { }

  get status(){
    return Status;
  }
  ngOnInit(): void {
    this.load();
  }

  load(){
    this.orderList = this._os.GetAll();
  }

  setStatus(id : number, status : Status){
    this._os.SetStatus(id, status).subscribe(res => {alert("Done!"); this.load();}, err => alert(err.message))
  }
}
