import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './@pag/home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthGuard } from './@elements/service/auth.guard';
import { ConsultarConsultasComponent } from './historia/consultar-consultas/consultar-consultas.component';
import { RegistrarConsultaComponent } from './historia/registrar-consulta/registrar-consulta.component';
import { AgendaMedicoComponent } from './odontologo/agenda-medico/agenda-medico.component';
import { RegistrarOdontologoComponent } from './odontologo/registrar-odontologo/registrar-odontologo.component';
import { SolicitarCitaComponent } from './paciente/solicitar-cita/solicitar-cita.component';
import { UsuarioRegistroComponent } from './Paciente/usuario-registro/usuario-registro.component';
import { ProductoComponent } from './servicios/producto/producto.component';
import { ServicioComponent } from './servicios/servicio/servicio.component';
import { UserSessionComponent } from './user-session/user-session.component';

const routes: Routes = [

  { path: 'registroUsuario', component: UsuarioRegistroComponent},
  { path: 'solicitarCita', component: SolicitarCitaComponent},
  { path: 'login', component: UserSessionComponent},

    { path: 'home', component: HomeComponent, canActivate: [AuthGuard]}, 
  { path: 'agendaMedico', component: AgendaMedicoComponent, canActivate: [AuthGuard]},
  { path: 'registrarConsulta', component: RegistrarConsultaComponent, canActivate: [AuthGuard]},
  { path: 'servicios', component: ServicioComponent, canActivate: [AuthGuard]},
  { path: 'productos', component: ProductoComponent, canActivate: [AuthGuard]},
  { path: 'pacienteConsultas', component:ConsultarConsultasComponent, canActivate: [AuthGuard]},
  { path: 'registrarMedico', component: RegistrarOdontologoComponent, canActivate: [AuthGuard]},
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })
  ]
})
export class AppRoutingModule { }
