import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { AppComponent } from "./app.component";
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

//-------------------------------------------------------Angular CLI--------------------------------------------------
import { DashboardComponent } from "./@pag/dashboard/dashboard.component";
import { RouterModule } from "@angular/router";
import { AppRoutingModule } from "./app-routing.module";
import { NavMenuComponent } from "./@pag/nav-menu/nav-menu.component";
import { HomeComponent } from "./@pag/home/home.component";
import { FooterComponent } from "./@pag/footer/footer.component";
import { UsuarioRegistroComponent } from "./Paciente/usuario-registro/usuario-registro.component";
import { UsuarioConsultaComponent } from "./Paciente/usuario-consulta/usuario-consulta.component";
import { HistorialClinicoComponent } from "./Paciente/historial-odontologico/historial-clinico.component";
import { FiltroPacientePipe } from "./@elements/pipe/filtro-paciente.pipe";
import { ServicioComponent } from "./servicio/servicio.component";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { AlertModalComponent } from "./@base/alertModal/alertModal.component";
import { AgendaMedicoComponent } from "./odontologo/agenda-medico/agenda-medico.component";
import { JwtInterceptor } from "./@elements/service/jwt.interceptor";
import { UserSessionComponent } from "./user-session/user-session.component";
import { RegistrarOdontologoComponent } from "./odontologo/registrar-odontologo/registrar-odontologo.component";
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatStepperModule} from '@angular/material/stepper';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
//---------------------------------------------------Routers---------------------------------------------------------------
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FooterComponent,
    UsuarioRegistroComponent,
    UsuarioConsultaComponent,
    HistorialClinicoComponent,
    ServicioComponent,
    FiltroPacientePipe,
    AgendaMedicoComponent,
    UserSessionComponent,
    RegistrarOdontologoComponent,
    DashboardComponent
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    MatButtonModule,
    MatPaginatorModule,
    MatInputModule,
    MatButtonModule,
    MatStepperModule,
    NgbModule,
    MatTableModule,
    RouterModule.forRoot(
      [{ path: "", component: HomeComponent, pathMatch: "full" }],
      { relativeLinkResolution: "legacy" }
    ),
    AppRoutingModule,
  ],
  entryComponents: [AlertModalComponent],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent,],
})
export class AppModule {}
