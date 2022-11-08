import { Component, Inject, Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse
} from '@angular/common/http';
import { Observable, finalize, tap } from 'rxjs';
import { LoadingStateService } from '../services/loadingstateService/loading-state.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AlertComponent } from '../dialogs/alert/alert.component';


@Injectable()
export class HttpMainInterceptor implements HttpInterceptor {




  constructor(private loadServ: LoadingStateService,
    public dialog: MatDialog) {
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {


    this.loadServ.Show();
    return next.handle(request).pipe(tap(event => event, errorResponse => {
      console.log("here!")
      if (errorResponse?.error?.errorMessage) {
        this.dialog.open(AlertComponent, {
          data: { text: errorResponse?.error?.errorMessage, restoreFocus: false  },
        })
      }
      else if(errorResponse?.error?.errors){
       
         this.dialog.open(AlertComponent, {
           data: { text: Object.values(errorResponse?.error?.errors)[0], restoreFocus: false  },
        })
      }
      else {
        this.dialog.open(AlertComponent, {
          data: { text: 'Something went wrong.', restoreFocus: false },
        })
      }


    }), finalize(() => this.loadServ.Hide()));
  }
}



// tap(
//   event => event,
//   err => {
//     return;
//     if(err?.error?.errorMessage){
//       this.dialog.open(this.simpleDialog, {
//         data: { text: err?.error?.errorMessage },
//       })
//     }
//     else{
//       this.dialog.open(this.simpleDialog, {
//         data: { text: 'Something went wrong.' },
//       })
//     }
//   }
// )

