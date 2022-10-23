import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Status } from 'src/app/common/enums/Status';
import { TicketOrder } from 'src/app/common/models/order/TicketOrder';
import { TicketOrderService } from './../../common/services/ticketOrderService/ticket-order.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {

  orderList!: Observable<TicketOrder[]>;
  constructor(public _os : TicketOrderService) { }

  get status(){
    return Status;
  }
  ngOnInit(): void {
    this.load();
  }

  load(){
    this.orderList = this._os.GetMyOrders();
  }

  reject(id : number){
    this._os.Reject(id).subscribe(res => {alert("Done!"); this.load();}, err => alert(err.message))
  }
}
