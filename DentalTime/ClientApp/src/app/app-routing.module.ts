import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import {LoginUserComponent} from './User/login-user/login-user.component';
import {RegisterUserComponent} from './User/register-user/register-user.component';
import { HomeComponent } from './home/home.component';
import { UsuarioRegistroComponent } from './Usuario/usuario-registro/usuario-registro.component';
import { UsuarioConsultaComponent } from './Usuario/usuario-consulta/usuario-consulta.component';

const routes: Routes = [
{
  path: 'login',
  component: LoginUserComponent,
},

{
  path: 'register',
  component: RegisterUserComponent,
},

{
  path: 'home',
  component: HomeComponent,
},
{
  path: 'registroUsuario',
  component: UsuarioRegistroComponent,
},
{
  path: 'consultaUsuario',
  component: UsuarioConsultaComponent,
}

];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ]
})
export class AppRoutingModule { }
