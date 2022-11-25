import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
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

  orderList!: TicketOrder[];
  constructor(public _os : TicketOrderService,
              private _snackBar: MatSnackBar) { }

  get status(){
    return Status;
  }
  ngOnInit(): void {
    this.load();
  }

  load(){
    this._os.GetMyOrders().subscribe(data => {
      this.orderList = data;
    });
  }

  reject(id : number){
    this._os.Reject(id).subscribe(res => {this._snackBar.open('Order was rejected!', 'Ok'); this.load();})
  }
}
