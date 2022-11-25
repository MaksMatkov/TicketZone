import { SelectionModel } from '@angular/cdk/collections';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';
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
  displayedColumns: string[] = [ 'filmName', 'roomNumber', 'userEmail', 'creationDate', 'status'];
  dataSource! : MatTableDataSource<TicketOrder>;
  selection = new SelectionModel<TicketOrder>(true, []);
  
  constructor(public _os : TicketOrderService,
              private _snackBar: MatSnackBar ) { }

  get status(){
    return Status;
  }
  ngOnInit(): void {
    this.load();
  }

  load(){
    this._os.GetAll().subscribe(data => {
      this.dataSource = new MatTableDataSource<TicketOrder>(data)
    });
  }

  setStatus(id : number | undefined, status : Status){
    if(id)
      this._os.SetStatus(id, status).subscribe(res => {this._snackBar.open('Status was changed!', 'Ok');},)
  }

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ?
        this.selection.clear() :
        this.dataSource.data.forEach(row => this.selection.select(row));
  }
}
