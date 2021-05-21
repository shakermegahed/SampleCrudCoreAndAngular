import { Observable } from 'rxjs';

import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from "@angular/router";

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(
    private Router: Router) { }

  canActivate(    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {


        return false;
    

  }

    // if (this.AuthService.loggedIn()) {
    //   return true
    // } else {
    //   this.Router.navigate(['/login'])
    //   return false
    // }


}
