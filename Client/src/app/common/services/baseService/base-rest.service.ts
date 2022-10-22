import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class BaseRestService<LiteT, FullT, PostT> extends BaseService {
  endPoint = "";

  public GetAll(): Observable<LiteT[]> {
    return this.http.get(this.apiUrl + this.endPoint).pipe(
      map(res => {
        return <LiteT[]>res;
      }));
  }

  public GetById(id : number): Observable<FullT> {
    return this.http.get(this.apiUrl + this.endPoint + `/${id}`).pipe(
      map(res => {
        return <FullT>res;
      }));
  }

  public Save(item: PostT) : Observable<any>{
    return this.http.post(this.apiUrl + this.endPoint, item).pipe(map(res => <any>res));
  } 

  public Put(item: PostT, id: number) : Observable<any>{
    return this.http.put(this.apiUrl + this.endPoint + `/${id}`, item).pipe(map(res => <any>res));
  } 
  
  public Delete(id : number) : Observable<boolean>{
    return this.http.delete(this.apiUrl + this.endPoint + `/${id}`).pipe(
      map(res =>  <boolean>res ));
  }

}
