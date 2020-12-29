import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from './services/auth.service';

@Injectable()
export class JwtInterceptorInterceptor implements HttpInterceptor {

  constructor(private userService: AuthService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let bearerToken = this.userService.currentBearerTokenValue;

    if (bearerToken) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${bearerToken}`,
          'Access-Control-Allow-Origin':'*',
        }
      });
    }
    else {
      request = request.clone({
        setHeaders: {
          'Access-Control-Allow-Origin':'*',
        }
      });
    }

    return next.handle(request);
  }
}
