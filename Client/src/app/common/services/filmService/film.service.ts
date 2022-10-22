import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { AddFilm } from '../../models/film/AddFilm';
import { Film } from '../../models/film/Film';
import { FilmLite } from '../../models/film/FilmLite';
import { BaseRestService } from '../baseService/base-rest.service';
import { BaseService } from '../baseService/base.service';
import { AuthDaSettings } from '../servicesEndpoints';

@Injectable({
  providedIn: 'root'
})
export class FilmService extends BaseRestService<FilmLite, Film, AddFilm> {

  override endPoint =  AuthDaSettings.filmsEndpoint;
}
