import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { AppComponent } from "./app.component";
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

//-------------------------------------------------------Angular CLI--------------------------------------------------

import { RouterModule } from "@angular/router";
import { AppRoutingModule } from "./app-routing.module";
import { NavMenuComponent } from "./@pag/nav-menu/nav-menu.component";
import { HomeComponent } from "./@pag/home/home.component";
import { FooterComponent } from "./@pag/footer/footer.component";
import { UsuarioRegistroComponent } from "./Paciente/usuario-registro/usuario-registro.component";
import { FiltroPacientePipe } from "./@elements/pipe/filtro-paciente.pipe";
import { ServicioComponent } from "./servicios/servicio/servicio.component";
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
import {MatDividerModule} from '@angular/material/divider';
import {MatSelectModule} from '@angular/material/select';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { SolicitarCitaComponent } from "./paciente/solicitar-cita/solicitar-cita.component";
import { DashboardComponent } from "./@pag/dashboard/dashboard.component";
import {MatDialogModule} from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import { DialogSolicitarCitaComponent } from "./@base/dialog-solicitar-cita/dialog-solicitar-cita.component";
import { ConsultarConsultasComponent } from "./historia/consultar-consultas/consultar-consultas.component";


//---------------------------------------------------Routers---------------------------------------------------------------
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FooterComponent,
    UsuarioRegistroComponent,
    ServicioComponent,
    FiltroPacientePipe,
    AgendaMedicoComponent,
    UserSessionComponent,
    RegistrarOdontologoComponent,
    SolicitarCitaComponent,
    DashboardComponent,
    DialogSolicitarCitaComponent,
    ConsultarConsultasComponent
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
    MatFormFieldModule,
    MatDividerModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    NgbModule,
    MatTableModule,
    MatDialogModule,
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
