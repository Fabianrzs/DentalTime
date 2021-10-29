import { Component, OnInit } from '@angular/core';
import { Paciente } from 'src/app/models/Paciente';
import { PacienteService } from 'src/app/service/paciente.service';

@Component({
  selector: 'app-usuario-consulta',
  templateUrl: './usuario-consulta.component.html',
  styleUrls: ['./usuario-consulta.component.css']
})
export class UsuarioConsultaComponent implements OnInit {

  searchText: string;

  pacientes: Paciente[];

  constructor(private service: PacienteService) { }

  ngOnInit() {
    this.get();
  }
  get() {
    this.service.get().subscribe(result => {
      this.pacientes = result;
    });
  }
}
