import { AuthService, ConfigStateService, RoutesService } from '@abp/ng.core';
import { AfterViewInit, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {

  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated;
  }

  constructor(private authService: AuthService , 
    private config: ConfigStateService,
    private router:Router) {
    if (!this.authService.isAuthenticated) this.router.navigateByUrl("/welcome");
  }

  login() {
    this.authService.navigateToLogin();
  }
  
}
