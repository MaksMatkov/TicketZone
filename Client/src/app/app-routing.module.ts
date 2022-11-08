import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationGuardClientService } from './common/services/authGuardService/authentication-guard-client.service';
import { AuthenticationGuardAdminService } from './common/services/authGuardService/authentication-guard.service';
import { AdminControlComponent } from './components/admins/admin-control/admin-control.component';
import { FilmEditComponent } from './components/admins/filmManager/film-edit/film-edit.component';
import { FilmViewComponent } from './components/admins/filmManager/film-view/film-view.component';
import { OrdersViewComponent } from './components/admins/filmManager/orders-view/orders-view.component';
import { ViewsTimesViewComponent } from './components/admins/filmManager/views-times-view/views-times-view.component';
import { RoomEditComponent } from './components/admins/roomManager/room-edit/room-edit.component';
import { RoomListComponent } from './components/admins/roomManager/room-list/room-list.component';
import { UsersListComponent } from './components/admins/userManager/users-view/users-list/users-list.component';
import { FilmsListComponent } from './components/films-list/films-list.component';
import { LoginComponent } from './components/login-components/login/login.component';
import { OrdersComponent } from './components/orders/orders.component';
import { ViewFilmComponent } from './components/view-film/view-film.component';

const routes: Routes = [
  { path: '', component: FilmsListComponent},

  { path: 'login', component: LoginComponent},

  { path: 'admin', component: AdminControlComponent, canActivate: [AuthenticationGuardAdminService],
  children: [
    {path:"", component: FilmViewComponent},
    {path:"rooms", component: RoomListComponent},
    {path:"users", component: UsersListComponent},
    {path: 'films-viewing-time/:id', component:ViewsTimesViewComponent},
    {path: 'room-edit/:id', component:RoomEditComponent},
    { path: 'room-edit', component: RoomEditComponent },
    { path: 'film-edit/:id', component: FilmEditComponent },
    { path: 'film-edit', component: FilmEditComponent },
    { path: 'orders', component: OrdersViewComponent}
  ] },

  { path: 'film/:id', component: ViewFilmComponent },
  { path:"orders", component: OrdersComponent, canActivate: [AuthenticationGuardClientService]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
