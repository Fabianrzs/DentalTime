import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/@elements/models/user';
import { AuthenticationService } from 'src/app/@elements/service/authentication.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  currentUser:User;
  router: any;

  constructor(
    private authenticationService: AuthenticationService
  ) {
    this.authenticationService.currentUser.subscribe(
      (x) => (this.currentUser = x)
    );
  }

  ngOnInit() {
  }
  logout() {
    window.location.reload();
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  } 

}
