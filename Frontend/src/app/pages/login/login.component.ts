import { Component } from '@angular/core';
import { Router } from '@angular/router';

// Services
import { LoginService } from '../../services/login.service'

// Models
import { Login } from 'src/app/models/login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  isLoading: boolean = false;
  keepConnected: boolean = false;

  constructor(
    private loginService: LoginService,
    private router: Router) { }

  handleCheckbox(event: any) {
    this.keepConnected = event.target?.checked;
  }

  // Faz o request para a API para logar
  async login() {
    try {
      const login = (document.getElementById('login') as HTMLInputElement).value;
      const password = (document.getElementById('password') as HTMLInputElement).value;
      
      if (login !== '' && password !== '') {
        this.isLoading = true;

        const result = await this.loginService.login(login, password) as Login;
        await this.handleLoginResult(result);
  
        this.isLoading = false;
      }
    } catch (error) {
      console.log(error);
    }
  }

  // Pega o resultado do login e gera os Cookies e Session
  async handleLoginResult(loginData: Login) {
    try {
      const date = new Date();
      date.setTime(date.getTime() + 30 * 24 * 60 * 60 * 1000); // 30 dias para frente
      date.toUTCString();

      // Cria os cookies
      if (this.keepConnected) {
        document.cookie = `avocadoStore__login=${loginData.userData.st_login}; expires=${date}; path=/; SameSite=none; secure;`;
        document.cookie = `avocadoStore__password=${loginData.userData.st_password}; expires=${date}; path=/; SameSite=none; secure;`;
        document.cookie = `avocadoStore__keepConnected=true; expires=${date}; path=/; SameSite=none; secure;`;
      }

      // Cria a "session"
      localStorage.setItem('avocadoStore__userData', JSON.stringify(loginData.userData));
      localStorage.setItem('avocadoStore__token', loginData.token);

      // Redireciona o usuário para a tela Dashboard
      this.router.navigate(['dashboard']);
    } catch (error) {
      console.log(error);
    }
  }

}
