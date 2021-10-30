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
  view = false;
  PACIENTES: Paciente[];  
  page = 1;
  pageSize = 4;
  collectionSize = 0;
  pacientes: Paciente[];
  paciente: Paciente;

  constructor(public service: PacienteService) { }

  ngOnInit() {
    this.get();
  }
  get() {
    this.service.get().subscribe(result => {
      this.PACIENTES = result;
      this.collectionSize = this.PACIENTES.length;
      this.pacientes = this.PACIENTES
      .map((paciente, i) => ({noDocumento: i + 1, ...paciente}))
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
    });
  }

  
  onSearch(id: string){
    this.view = true;
    alert(id)
    this.service.getId(id).subscribe(result => {
      this.paciente = result;
      alert(this.paciente);
    });
  }
}
