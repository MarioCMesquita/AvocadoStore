import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

// Models
import { Login } from '../models/login.model';

@Injectable({
  providedIn: 'root'
})

export class LoginService {

  constructor(protected httpClient: HttpClient) { }

  async login(login: string, password: string) {
    return this.httpClient.post<Login>(`${environment.urlApi}/Login?login=${login}&password=${password}`, {}).toPromise();
  }
}
