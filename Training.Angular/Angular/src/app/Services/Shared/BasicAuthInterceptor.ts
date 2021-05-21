import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Observable, throwError } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class BasicAuthInterceptor implements HttpInterceptor {


  constructor(private Router: Router) { }
  intercept(httpRequest: HttpRequest<any>,
     next: HttpHandler): Observable<HttpEvent<any>> {
       
      httpRequest =httpRequest.clone({
        setHeaders:{
         // 'Content-Type': 'application/json',
          'Authorization': localStorage.getItem("token") == null ? "" : localStorage.getItem("token").toString(),
          "Lang": localStorage.getItem('currentLang') || "ar"
        },
        //,
        //body: JSON.stringify(null)

      })
      return next.handle(httpRequest).pipe(



        catchError(err => {
          if (err instanceof HttpErrorResponse) {
  
            if (err.status === 401 ) {
                localStorage.clear();
                this.Router.navigate(['/login']);
            }
  
        
  
            // return the error back to the caller
            return throwError(err);
          }
        }),
        finalize(() => {
          // any cleanup or final activities.
        })
      )
    }

    

}
