import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './@pag/home/home.component';
import { UsuarioRegistroComponent } from './Paciente/usuario-registro/usuario-registro.component';
import { UsuarioConsultaComponent } from './Paciente/usuario-consulta/usuario-consulta.component';
import { HistorialClinicoComponent } from './Paciente/historial-odontologico/historial-clinico.component';
import { ServicioComponent } from './servicio/servicio.component';
import { AgendaMedicoComponent } from './odontologo/agenda-medico/agenda-medico.component';
import { AuthGuard } from './@elements/service/auth.guard';
import { RegistrarOdontologoComponent } from './odontologo/registrar-odontologo/registrar-odontologo.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent, },
  { path: 'registroUsuario', component: UsuarioRegistroComponent, canActivate: [AuthGuard]},
  { path: 'consultaUsuario', component: UsuarioConsultaComponent, canActivate: [AuthGuard]},
  { path: 'historialClinico/:noDocumentoPaciente', component: HistorialClinicoComponent, canActivate: [AuthGuard]},
  { path: 'registrarServicio', component:ServicioComponent, canActivate: [AuthGuard]},
  { path: 'registrarConsulta/:noDocumentoPaciente', component: UsuarioRegistroComponent, canActivate: [AuthGuard]},
  { path: 'agendaMedico', component: AgendaMedicoComponent, canActivate: [AuthGuard]},
  { path: 'registrarMedico', component: RegistrarOdontologoComponent, canActivate: [AuthGuard]},
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })
  ]
})
export class AppRoutingModule { }
