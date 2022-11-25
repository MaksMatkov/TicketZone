import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './components/header/header.component';
import { FilmsListComponent } from './components/films-list/films-list.component';

import {MatInputModule} from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';
import {MatGridListModule} from '@angular/material/grid-list';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JwtModule } from '@auth0/angular-jwt';
import { tokenData } from './common/models/tokenData';
import { environment } from 'src/environments/environment';

import {MatListModule} from '@angular/material/list';
import {MatDialogModule} from '@angular/material/dialog';

import {MatTabsModule} from '@angular/material/tabs';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoginComponent } from './components/login-components/login/login.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatButtonModule} from '@angular/material/button';
import { FilmViewComponent } from './components/admins/filmManager/film-view/film-view.component';
import { OrdersViewComponent } from './components/admins/filmManager/orders-view/orders-view.component';
import { ViewsTimesViewComponent } from './components/admins/filmManager/views-times-view/views-times-view.component';
import { FilmEditComponent } from './components/admins/filmManager/film-edit/film-edit.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import { UsersListComponent } from './components/admins/userManager/users-view/users-list/users-list.component';
import { ViewFilmComponent } from './components/view-film/view-film.component';
import {MatCardModule} from '@angular/material/card';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { RoomListComponent } from './components/admins/roomManager/room-list/room-list.component';
import {MatSelectModule} from '@angular/material/select';
import { OrdersComponent } from './components/orders/orders.component';
import { AdminControlComponent } from './components/admins/admin-control/admin-control.component';
import { RoomEditComponent } from './components/admins/roomManager/room-edit/room-edit.component';
import { HttpMainInterceptor } from './common/interceptors/http.interceptor';
import { CommonModule } from '@angular/common';
import { AlertComponent } from './common/dialogs/alert/alert.component';
import {MatTableModule} from '@angular/material/table';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { OrderStatusPipe } from './common/pipes/order-status.pipe';
import { AccountComponent } from './components/account/account.component';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatBadgeModule} from '@angular/material/badge';
import { NotFoundComponent } from './components/not-found/not-found.component';

export function tokenGetter() {
  let key = 'jwt';


  if (!key) {
    return null;
  }

  const res = localStorage.getItem(key);

  if (res) {
    let model = JSON.parse(res) as tokenData;

    return model.access_token || null;
  }

  return null;


}

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FilmsListComponent,
    LoginComponent,
    FilmViewComponent,
    OrdersViewComponent,
    ViewsTimesViewComponent,
    FilmEditComponent,
    UsersListComponent,
    ViewFilmComponent,
    RoomListComponent,
    OrdersComponent,
    AdminControlComponent,
    RoomEditComponent,
    AlertComponent,
    OrderStatusPipe,
    AccountComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatButtonModule,
    MatListModule,
    MatToolbarModule,
    MatCardModule,
    MatProgressBarModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSelectModule,
    MatDialogModule,
    CommonModule,
    MatTableModule,
    MatCheckboxModule,
    MatSnackBarModule,
    MatBadgeModule,

    MatTabsModule,
    MatInputModule,
    MatIconModule,
    MatGridListModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:44354"],
        disallowedRoutes: []
      }
    }),
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: HttpMainInterceptor,
    multi: true,
  }],
  bootstrap: [AppComponent],
  entryComponents: [
    ]
})
export class AppModule { }
