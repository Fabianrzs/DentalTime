import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import {LoginUserComponent} from './User/login-user/login-user.component';
import {RegisterUserComponent} from './User/register-user/register-user.component';
import { HomeComponent } from './home/home.component';

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
