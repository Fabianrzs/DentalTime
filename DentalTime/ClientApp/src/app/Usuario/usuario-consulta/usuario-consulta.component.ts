import { Component, OnInit } from '@angular/core';
import { Paciente } from 'src/app/models/Paciente';
import { PacienteServiceService } from 'src/app/service/pacienteService.service';

@Component({
  selector: 'app-usuario-consulta',
  templateUrl: './usuario-consulta.component.html',
  styleUrls: ['./usuario-consulta.component.css']
})
export class UsuarioConsultaComponent implements OnInit {

  searchText: string;

  pacientes: Paciente[];

  constructor(private service: PacienteServiceService) { }

  ngOnInit() {
    this.get();
  }
  get() {
    this.service.get().subscribe(result => {
      this.pacientes = result;
    });
  }

}
