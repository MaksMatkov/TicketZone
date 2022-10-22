import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FilmLite } from 'src/app/common/models/film/FilmLite';
import { FilmService } from 'src/app/common/services/filmService/film.service';

@Component({
  selector: 'app-film-view',
  templateUrl: './film-view.component.html',
  styleUrls: ['./film-view.component.scss']
})
export class FilmViewComponent implements OnInit {

  filmList!: Observable<FilmLite[]>;

  constructor(public _fs : FilmService) { }

  ngOnInit(): void {
    this.filmList = this._fs.GetAll();
  }


 

}
