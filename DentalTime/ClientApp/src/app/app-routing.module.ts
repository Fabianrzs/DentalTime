import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginUserComponent } from './User/login-user/login-user.component';
import { RegisterUserComponent } from './User/register-user/register-user.component';
import { HomeComponent } from './home/home.component';
import { UsuarioRegistroComponent } from './Usuario/usuario-registro/usuario-registro.component';
import { UsuarioConsultaComponent } from './Usuario/usuario-consulta/usuario-consulta.component';
import { AgendarCitaComponent } from './Agenda/agendar-cita/agendar-cita.component';
import { ConsultarCitasComponent } from './Agenda/consultar-citas/consultar-citas.component';
import { ConsultarServicioComponent } from './Servicio/consultar-servicio/consultar-servicio.component';
import { RegistrarServicioComponent } from './Servicio/registrar-servicio/registrar-servicio.component';
import { InformeComponent } from './informe/informe.component';
import { RealizarFacturaComponent } from './Facturacion/realizar-factura/realizar-factura.component';
import { HistorialClinicoComponent } from './Usuario/historial-clinico/historial-clinico.component';
import { HistorialFacturaComponent } from './Facturacion/historial-factura/historial-factura.component';
import { RegistrarConsultaComponent } from './Usuario/registrar-consulta/registrar-consulta.component';
import { GestionInventarioComponent } from './Inventario/gestion-inventario/gestion-inventario.component';
import { ProductoRegistroComponent } from './Inventario/producto-registro/producto-registro.component';

const routes: Routes = [
  { path: 'login', component: LoginUserComponent, },
  { path: 'register', component: RegisterUserComponent, },
  { path: 'home', component: HomeComponent, },
  { path: 'registroUsuario', component: UsuarioRegistroComponent, },
  { path: 'consultaUsuario', component: UsuarioConsultaComponent, },
  { path: 'historialClinico', component: HistorialClinicoComponent, },
  { path: 'registrarAgenda', component: AgendarCitaComponent, },
  { path: 'consultarCita', component:ConsultarCitasComponent},
  { path: 'consultarServicio', component:ConsultarServicioComponent},
  { path: 'registrarServicio', component:RegistrarServicioComponent},
  { path: 'registrarFactura', component:RealizarFacturaComponent}, 
  { path: 'consultarFactura', component:HistorialFacturaComponent},
  { path: 'informe', component:InformeComponent},
  { path: 'registrarConsulta', component: RegistrarConsultaComponent},
  { path: 'registroProducto', component: ProductoRegistroComponent},
  { path: 'gestionInventario', component: GestionInventarioComponent}
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })
  ]
})
export class AppRoutingModule { }
