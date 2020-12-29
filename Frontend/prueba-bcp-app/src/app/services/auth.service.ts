import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { UserInfo } from '../interfaces/user-info';
import { UserToken } from '../interfaces/user-token';
import { environment } from 'src/environments/environment';
import { map } from "rxjs/operators";


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private currentBearerTokenSubject: BehaviorSubject<string>;
  public currentBearerToken: Observable<string>;

  private readonly BEARER_TOKEN_PREFIX = 'currentBearerToken';

  constructor(private http: HttpClient) {
    this.currentBearerTokenSubject = new BehaviorSubject<string>(localStorage.getItem(this.BEARER_TOKEN_PREFIX));
    this.currentBearerToken = this.currentBearerTokenSubject.asObservable();
  }

  public get currentBearerTokenValue(): string {
    return this.currentBearerTokenSubject.value;
  }

  login(request: UserInfo) {
    return this.http.post<UserToken>(`${environment.baseUrl}auth`, request)
      .pipe( map(response => {
        localStorage.setItem(this.BEARER_TOKEN_PREFIX, response.token);
        this.currentBearerTokenSubject.next(response.token);
        return response;
      }));
  }

  logout() {
    localStorage.removeItem(this.BEARER_TOKEN_PREFIX);
    this.currentBearerTokenSubject.next(null);
  }

}