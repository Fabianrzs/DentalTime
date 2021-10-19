import { Component, OnInit } from '@angular/core';
import { Paciente } from 'src/app/models/Paciente';

@Component({
  selector: 'app-usuario-registro',
  templateUrl: './usuario-registro.component.html',
  styleUrls: ['./usuario-registro.component.css']
})
export class UsuarioRegistroComponent implements OnInit {

  paciente: Paciente;

  constructor() { }
  

  ngOnInit() {
    this.paciente = new Paciente();
  }

}
