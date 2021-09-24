import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
//-------------------------------------------------------Angular CLI--------------------------------------------------



import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatInputModule} from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
//-------------------------------------------------------Angular Material -------------------------------------------



import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FooterComponent } from './footer/footer.component';
import { LoginUserComponent } from './User/login-user/login-user.component';
import { RegisterUserComponent } from './User/register-user/register-user.component';
import { UsuarioRegistroComponent } from './Usuario/usuario-registro/usuario-registro.component';
import { UsuarioConsultaComponent } from './Usuario/usuario-consulta/usuario-consulta.component';
import { HistorialClinicoComponent } from './Usuario/historial-clinico/historial-clinico.component';
import { AgendarCitaComponent } from './Agenda/agendar-cita/agendar-cita.component';
import { ConsultarCitasComponent } from './Agenda/consultar-citas/consultar-citas.component';
import { RegistrarServicioComponent } from './Servicio/registrar-servicio/registrar-servicio.component';
import { ConsultarServicioComponent } from './Servicio/consultar-servicio/consultar-servicio.component';
import { InformeComponent } from './informe/informe.component';
import { RealizarFacturaComponent } from './Facturacion/realizar-factura/realizar-factura.component';
import { HistorialFacturaComponent } from './Facturacion/historial-factura/historial-factura.component';
//---------------------------------------------------Routers---------------------------------------------------------------


import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatNativeDateModule } from '@angular/material/core';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FooterComponent,
    LoginUserComponent,
    RegisterUserComponent,
    UsuarioRegistroComponent,
    UsuarioConsultaComponent,
    HistorialClinicoComponent,
    AgendarCitaComponent,
    ConsultarCitasComponent,
    RegistrarServicioComponent,
    ConsultarServicioComponent,
    InformeComponent,
    RealizarFacturaComponent,
    HistorialFacturaComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
    ]),
    AppRoutingModule,
    NgbModule,
    BrowserAnimationsModule,
    MatDatepickerModule,
    MatInputModule,
    MatFormFieldModule,
    MatNativeDateModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
