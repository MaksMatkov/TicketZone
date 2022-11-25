import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FilmLite } from 'src/app/common/models/film/FilmLite';
import { FilmService } from 'src/app/common/services/filmService/film.service';
import { SelectionModel } from '@angular/cdk/collections';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-film-view',
  templateUrl: './film-view.component.html',
  styleUrls: ['./film-view.component.scss']
})
export class FilmViewComponent implements OnInit {

  filmList!: Observable<FilmLite[]>;
  showViewingTime = false;
  filmIdViewingTime = 0;

  displayedColumns: string[] = ['select', 'name'];
  dataSource! : MatTableDataSource<FilmLite>;
  selection = new SelectionModel<FilmLite>(true, []);

  constructor(public _fs : FilmService,
              private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.reload();
  }

  reload(){
    this._fs.GetAll().subscribe(data => {
      this.dataSource = new MatTableDataSource<FilmLite>(data);
      this.selection.clear()
    });
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
      this._fs.Delete(id).subscribe((data) => {this._snackBar.open('Done!', 'Ok'); this.reload()})
  }


 
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ?
        this.selection.clear() :
        this.dataSource.data.forEach(row => this.selection.select(row));
  }

}
