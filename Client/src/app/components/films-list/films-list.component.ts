import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
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

  searchInput : string | undefined = undefined;
  cols = 4;
  lastTimeOut : any;

  @ViewChild("searchInput") input : any;
  filmList!: Observable<FilmLite[]>;

  constructor(public _fs : FilmService, private router: Router) { }

  ngOnInit(): void {
    this.setColsCount(window.innerWidth)
    this.reload();
  }

  get showBtn() : boolean{
    return !(!this.searchInput);
  }

  reload() : void {
    this.filmList = this._fs.GetAllWithSearch(this.searchInput);
  }

  saveInput(){
    if(this.lastTimeOut)
      clearTimeout(this.lastTimeOut);
    this.searchInput = this.input.nativeElement.value;
    this.lastTimeOut = setTimeout(() => {this.reload();}, 500)
  }

  clear(){
    if(this.lastTimeOut)
      clearTimeout(this.lastTimeOut);
    this.searchInput = undefined;
    this.input.nativeElement.value = "";
    this.reload();
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
