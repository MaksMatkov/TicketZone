import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Film } from 'src/app/common/models/film/Film';
import { FilmService } from 'src/app/common/services/filmService/film.service';
import {switchMap} from 'rxjs';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AddFilm } from 'src/app/common/models/film/AddFilm';


@Component({
  selector: 'app-film-edit',
  templateUrl: './film-edit.component.html',
  styleUrls: ['./film-edit.component.scss']
})
export class FilmEditComponent implements OnInit {

  filmId = 0
  film! : Film;

  public filmForm: FormGroup = new FormGroup({
    name: new FormControl('', [Validators.required]),
    description: new FormControl('', Validators.required),
    posterUrl: new FormControl('', Validators.required),
    trailerUrl: new FormControl('', Validators.required),
  });

  get nameForm() {
    return this.filmForm.controls['name'] as FormControl;
  }

  get descriptionForm() {
    return this.filmForm.controls['description'] as FormControl;
  }

  get posterForm() {
    return this.filmForm.controls['posterUrl'] as FormControl;
  }

  get trailerForm() {
    return this.filmForm.controls['trailerUrl'] as FormControl;
  }


  constructor(public route: ActivatedRoute, public _fs :FilmService, private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.filmId = params['id'];
      if(this.filmId){
        this._fs.GetById(this.filmId).subscribe(data => {
          this.film = data;
          this.initData();
        })
      }
    });
  }

  initData(){
    this.nameForm.reset(this.film.name);
    this.descriptionForm.reset(this.film.description);

    this.posterForm.reset(this.film.posterUrl);
    this.trailerForm.reset(this.film.trailerUrl);
  }

  submit(){
    console.log("here")
    let inputModel = new AddFilm();
    inputModel.name = this.nameForm.value;
    inputModel.description = this.descriptionForm.value;
    inputModel.posterUrl = this.posterForm.value;
    inputModel.trailerUrl = this.trailerForm.value;

    if(this.film && this.film.id > 0){
      this._fs.Put(inputModel, this.film.id).subscribe(data => {
        this.router.navigate(['/admin']);
      }, err => alert("Something went wrong!"))
    }
    else {
      console.log("start saving")
      this._fs.Save(inputModel)
      .subscribe(data => this.router.navigate(['/admin']), 
      err => {alert("Something went wrong!"); console.log(err)});
    }
  }
}
