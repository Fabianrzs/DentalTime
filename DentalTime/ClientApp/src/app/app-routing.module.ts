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

const routes: Routes = [
  { path: 'login', component: LoginUserComponent, },
  { path: 'register', component: RegisterUserComponent, },
  { path: 'home', component: HomeComponent, },
  { path: 'registroUsuario', component: UsuarioRegistroComponent, },
  { path: 'consultaUsuario', component: UsuarioConsultaComponent, },
  { path: 'historialClinico/:noDocumentoPaciente', component: HistorialClinicoComponent, },
  { path: 'historialRegistro/:noDocumentoPaciente', component: HistorialRegistroComponent, },
  { path: 'registrarAgenda', component: SolicitudCitaComponent, },
  { path: 'registrarServicio', component:ServicioComponent},
  { path: 'informe', component:InformeComponent},
  { path: 'registrarConsulta/:noDocumentoPaciente', component: ConsultaRegistroComponent},
  { path: 'registroProducto', component: ProductoRegistroComponent},
  { path: 'gestionInventario', component: GestionInventarioComponent},
  
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })
  ]
})
export class AppRoutingModule { }
