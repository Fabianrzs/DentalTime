import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { first } from "rxjs/operators";
import { AlertModalComponent } from "src/app/@base/alertModal/alertModal.component";
import { User } from "src/app/@elements/models/user";
import { AuthenticationService } from "src/app/@elements/service/authentication.service";

@Component({
  selector: "app-user-session",
  templateUrl: "./user-session.component.html",
  styleUrls: ["./user-session.component.css"],
})
export class UserSessionComponent implements OnInit {
  loginForm: FormGroup;
  returnUrl: String;
  submitted: boolean;
  loading: boolean;
  user: User;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    private modalService: NgbModal
  ) {
    this.user = new User();
    // redirect to home if already logged in
    if (this.authenticationService.currentUserValue) {
      this.router.navigate(["/"]);
    }
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }
  
  get f() {
    return this.loginForm.controls;
  }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }
    this.loading = true;
    this.authenticationService
      .login(this.f.username.value, this.f.password.value)
      .pipe(first())
      .subscribe(
        (data) => {
          this.router.navigate(["/home"]);
        },
        (error) => {
          const modalRef = this.modalService.open(AlertModalComponent);
          modalRef.componentInstance.title = "Acceso Denegado";
          modalRef.componentInstance.message = "Usuario o Contraseña Erroneas";
          this.loading = false;
        }
      );
  }
}
