import { Component, HostListener, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Route, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { FilmLite } from 'src/app/common/models/film/FilmLite';
import { FilmService } from 'src/app/common/services/filmService/film.service';

@Component({
  selector: 'app-films-list',
  templateUrl: './films-list.component.html',
  styleUrls: ['./films-list.component.scss']
})
export class FilmsListComponent implements OnInit {

  searchInput = '';
  cols = 4;

  filmList!: Observable<FilmLite[]>;

  constructor(public _fs : FilmService, private router: Router) { }

  ngOnInit(): void {
    this.setColsCount(window.innerWidth)

    this.filmList = this._fs.GetAll();
  }

  reload() : void {
    this.filmList = this._fs.GetAll();
  }

  view(id : number){
    this.router.navigate(["/film", id])
  }

  @HostListener('window:resize', ['$event'])
  onResize(event : any) {
    this.setColsCount(event.target.innerWidth)
  }

  setColsCount(width : number){
    if(width < 850 && width > 600){
      this.cols = 2;
    }
    else if(width < 600){
      this.cols = 1;
    }
    else{
      this.cols = 4
    }
  }

}
