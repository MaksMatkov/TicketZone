import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { AddFilm } from '../../models/film/AddFilm';
import { Film } from '../../models/film/Film';
import { FilmLite } from '../../models/film/FilmLite';
import { ViewingTimeLite } from '../../models/viewingTimes/ViewingTimeLite';
import { BaseRestService } from '../baseService/base-rest.service';
import { BaseService } from '../baseService/base.service';
import { AuthDaSettings } from '../servicesEndpoints';

@Injectable({
  providedIn: 'root'
})
export class FilmService extends BaseRestService<FilmLite, Film, AddFilm> {

  override endPoint =  AuthDaSettings.filmsEndpoint;

  public GetViewingTimes(id : number): Observable<ViewingTimeLite[]> {
    return this.http.get(this.apiUrl + this.endPoint + `/${id}/viewingTimes`).pipe(
      map(res => {
        return <ViewingTimeLite[]>res;
      }));
  }

  public GetAllWithSearch(searchInput = ""): Observable<FilmLite[]> {
    return this.http.get(this.apiUrl + this.endPoint + "?searchInput=" + searchInput).pipe(
      map(res => {
        return <FilmLite[]>res;
      }));
  }
}
