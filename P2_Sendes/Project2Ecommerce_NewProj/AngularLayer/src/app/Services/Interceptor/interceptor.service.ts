import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent,HttpInterceptor } from '@angular/common/http';
import { AuthService } from '@auth0/auth0-angular';

import { Observable, throwError } from 'rxjs';
import { mergeMap, catchError } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class InterceptorService { 

  constructor(private auth: AuthService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return this.auth.getAccessTokenSilently().pipe(
      mergeMap(token => {
        const tokenReq = req.clone({
          setHeaders: { Authorization: `Bearer ${token}` }
        });
        return next.handle(tokenReq);
      }),
      catchError(err => throwError(() => new Error(err)))
    );
  }
}
