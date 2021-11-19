import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { User } from "src/app/@elements/models/user";
import { AuthenticationService } from "src/app/@elements/service/authentication.service";

@Component({
  selector: "app-nav-menu",
  templateUrl: "./nav-menu.component.html",
  styleUrls: ["./nav-menu.component.css"],
})
export class NavMenuComponent {
  isExpanded = false;
  nav = false;
  currentUser: User;
  constructor(
    private router: Router,
    private authenticationService: AuthenticationService
  ) {
    this.authenticationService.currentUser.subscribe(
      (x) => (this.currentUser = x)
    );
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }    

}
