import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { AppComponent } from "./app.component";

//-------------------------------------------------------Angular CLI--------------------------------------------------

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
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    NgbModule,
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
  bootstrap: [AppComponent],
})
export class AppModule {}
