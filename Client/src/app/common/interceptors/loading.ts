import {Injectable} from '@angular/core';
import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {finalize, Observable} from 'rxjs';
import { LoadingStateService } from '../services/loadingstateService/loading-state.service';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {

    constructor(private loadServ: LoadingStateService) {
    }

    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        
        this.loadServ.Show();
        return next.handle(request).pipe(finalize(() => this.loadServ.Hide()));
    }
}
