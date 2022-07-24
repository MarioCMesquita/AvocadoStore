import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable()
export class HttpGeneralInterceptor implements HttpInterceptor {

  constructor(private router: Router) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = localStorage.getItem('avocadoStore__token');
    let cloned = null;

    console.log(token);

    if (token) {
      cloned = request.clone({ headers: request.headers.set('Authorization', 'Bearer '.concat(token)) });
    }

    return next.handle(cloned ?? request).pipe(retry(1), catchError((error: HttpErrorResponse) => {
        let errorMessage = '';

        if (error.status === 401) {
          this.router.navigate(['login']); // Redireciona para o login quando o token expira
        }

        if (error.error instanceof ErrorEvent) {
          errorMessage = `Error: ${error.error.message}`; // Client Side
        } else {
          errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`; // Server Side
        }
        return throwError(errorMessage);
      })
    );
  }
}
