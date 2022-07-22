import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class LoginService {

  constructor(protected httpClient: HttpClient) { }

  async login(login: string, password: string) {
    return this.httpClient.post(`${environment.urlApi}/Login?login=${login}&password=${password}`, {}).toPromise();
  }
}
