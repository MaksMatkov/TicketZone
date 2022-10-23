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
  showViewingTime = false;
  filmIdViewingTime = 0;

  constructor(public _fs : FilmService) { }

  ngOnInit(): void {
    this.filmList = this._fs.GetAll();
  }

  reload(){
    this.filmList = this._fs.GetAll();
  }

  switchVTInfo(id : number){
    if(this.filmIdViewingTime == id){
      this.showViewingTime = false;
      this.filmIdViewingTime = 0;
      return;
    }
    this.filmIdViewingTime = id;
    this.showViewingTime = true;
  }

  onDeleteClick(id : number){
    if(confirm("Are you sure?"))
      this._fs.Delete(id).subscribe((data) => {this.reload()}, err => alert("Something went wrong!"))
  }


 

}
