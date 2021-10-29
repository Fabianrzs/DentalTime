import { Component, OnInit } from '@angular/core';
import { Paciente } from 'src/app/models/Paciente';
<<<<<<< HEAD
import { PacienteService } from 'src/app/service/paciente.service';
=======
import { PacienteService } from 'src/app/services/paciente.service';
>>>>>>> 46b6a98727ca27e29a9701e0ebf2ce521f31d793

@Component({
  selector: 'app-usuario-consulta',
  templateUrl: './usuario-consulta.component.html',
  styleUrls: ['./usuario-consulta.component.css']
})
export class UsuarioConsultaComponent implements OnInit {

  searchText: string;
  view = false;
  pacientes: Paciente[] = [];

<<<<<<< HEAD
  pacientes: Paciente[];

=======
>>>>>>> 46b6a98727ca27e29a9701e0ebf2ce521f31d793
  constructor(private service: PacienteService) { }

  ngOnInit() {
    this.get();
  }

  get() {  
    this.service.get().subscribe(result => {

      this.pacientes = result;
      alert(this.pacientes);
    });
  }
}
