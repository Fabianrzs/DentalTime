import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginUserComponent } from './userSession/login-user/login-user.component';
import { RegisterUserComponent } from './userSession/register-user/register-user.component';
import { HomeComponent } from './@pag/home/home.component';
import { UsuarioRegistroComponent } from './Paciente/usuario-registro/usuario-registro.component';
import { UsuarioConsultaComponent } from './Paciente/usuario-consulta/usuario-consulta.component';
import { InformeComponent } from './informe/informe.component';
import { HistorialClinicoComponent } from './Paciente/historial-odontologico/historial-clinico.component';
import { GestionInventarioComponent } from './Inventario/gestion-inventario/gestion-inventario.component';
import { ProductoRegistroComponent } from './Inventario/producto-registro/producto-registro.component';
import { HistorialRegistroComponent } from './Paciente/historial-registro/historial-registro.component';
import { SolicitudCitaComponent } from './solicitud-cita/solicitud-cita.component';
import { ServicioComponent } from './servicio/servicio.component';
import { ConsultaRegistroComponent } from './Paciente/consulta-registro/consulta-registro.component';
import { AgendaMedicoComponent } from './agenda-medico/agenda-medico.component';
import { AuthGuard } from './@elements/service/auth.guard';

const routes: Routes = [
  { path: 'login', component: LoginUserComponent, },
  { path: 'register', component: RegisterUserComponent, },
  { path: 'home', component: HomeComponent, },
  { path: 'registroUsuario', component: UsuarioRegistroComponent, canActivate: [AuthGuard]},
  { path: 'consultaUsuario', component: UsuarioConsultaComponent, canActivate: [AuthGuard]},
  { path: 'historialClinico/:noDocumentoPaciente', component: HistorialClinicoComponent, canActivate: [AuthGuard]},
  { path: 'historialRegistro/:noDocumentoPaciente', component: HistorialRegistroComponent, canActivate: [AuthGuard]},
  { path: 'registrarAgenda', component: SolicitudCitaComponent, canActivate: [AuthGuard]},
  { path: 'registrarServicio', component:ServicioComponent, canActivate: [AuthGuard]},
  { path: 'informe', component:InformeComponent, canActivate: [AuthGuard]},
  { path: 'registrarConsulta/:noDocumentoPaciente', component: ConsultaRegistroComponent, canActivate: [AuthGuard]},
  { path: 'registroProducto', component: ProductoRegistroComponent, canActivate: [AuthGuard]},
  { path: 'gestionInventario', component: GestionInventarioComponent, canActivate: [AuthGuard]},
  { path: 'agendaMedico', component: AgendaMedicoComponent, canActivate: [AuthGuard]},
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })
  ]
})
export class AppRoutingModule { }
