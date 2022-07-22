import { Component } from '@angular/core';

// Services
import { LoginService } from '../../services/login.service'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  isLoading: boolean = false;
  keepConnected: boolean = false;
  result:any = null;

  constructor(private loginService: LoginService) { }

  handleCheckbox(event: any) {
    this.keepConnected = event.target?.checked;
  }

  async login() {
    const login = (document.getElementById('login') as HTMLInputElement).value;
    const password = (document.getElementById('password') as HTMLInputElement).value;
    
    if (login !== '' && password !== '') {
      this.isLoading = true;
      this.result = await this.loginService.login(login, password);
      this.isLoading = false;
    }
  }

}
