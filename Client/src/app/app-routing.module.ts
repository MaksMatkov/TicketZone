import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationGuardAdminService } from './common/services/authGuardService/authentication-guard.service';
import { AdminMenuComponent } from './components/admins/admin-menu/admin-menu.component';
import { FilmEditComponent } from './components/admins/filmManager/film-edit/film-edit.component';
import { FilmsListComponent } from './components/films-list/films-list.component';
import { LoginComponent } from './components/login-components/login/login.component';

const routes: Routes = [
  { path: '', component: FilmsListComponent},

  { path: 'login', component: LoginComponent},

  { path: 'admin', component: AdminMenuComponent, canActivate: [AuthenticationGuardAdminService] },
  { path: 'film-edit/:id', component: FilmEditComponent, canActivate: [AuthenticationGuardAdminService] },
  { path: 'film-edit', component: FilmEditComponent, canActivate: [AuthenticationGuardAdminService] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
