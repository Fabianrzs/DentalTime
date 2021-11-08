import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';

//-------------------------------------------------------Angular CLI--------------------------------------------------

import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { NavMenuComponent } from './@pag/nav-menu/nav-menu.component';
import { HomeComponent } from './@pag/home/home.component';
import { FooterComponent } from './@pag/footer/footer.component';
import { LoginUserComponent } from './userSession/login-user/login-user.component';
import { RegisterUserComponent } from './userSession/register-user/register-user.component';
import { UsuarioRegistroComponent } from './Paciente/usuario-registro/usuario-registro.component';
import { UsuarioConsultaComponent } from './Paciente/usuario-consulta/usuario-consulta.component';
import { HistorialClinicoComponent } from './Paciente/historial-odontologico/historial-clinico.component';
import { InformeComponent } from './informe/informe.component';
import { ProductoRegistroComponent } from './Inventario/producto-registro/producto-registro.component';
import { GestionInventarioComponent } from './Inventario/gestion-inventario/gestion-inventario.component';
import { FiltroPacientePipe } from './@elements/pipe/filtro-paciente.pipe';
import { HistorialRegistroComponent } from './Paciente/historial-registro/historial-registro.component';
import { ServicioComponent } from './servicio/servicio.component';
import { ConsultaRegistroComponent } from './Paciente/consulta-registro/consulta-registro.component';
import { SolicitudCitaComponent } from './solicitud-cita/solicitud-cita.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from './@base/alertModal/alertModal.component';

//---------------------------------------------------Routers---------------------------------------------------------------
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
    ServicioComponent,
    InformeComponent,
    ConsultaRegistroComponent,
    ProductoRegistroComponent,
    GestionInventarioComponent,
    FiltroPacientePipe,
    HistorialRegistroComponent,
      SolicitudCitaComponent
   ],
  imports: [
    ReactiveFormsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    RouterModule.forRoot([
    { path: '', component: HomeComponent, pathMatch: 'full' },
    ], { relativeLinkResolution: 'legacy' }),
    AppRoutingModule
  ],
  entryComponents:[
    AlertModalComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
