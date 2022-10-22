import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { Role } from '../../enums/Role';
import { AuthService } from '../authService/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationGuardClientService implements CanActivate {
  constructor(private router: Router,
    private authService: AuthService,
    private jwtHelper: JwtHelperService) { }


  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    const currentUser = this.authService.currentUserValue;
    if (currentUser)
      return true;

    this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
    return false;
  }
}
