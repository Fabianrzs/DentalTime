import { Component, OnInit } from '@angular/core';
import { Paciente } from 'src/app/@elements/models/Paciente';
import { PacienteService } from 'src/app/@elements/service/paciente.service';
import Swal from 'sweetalert2';

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
  paciente: Paciente = new Paciente();

  constructor(public service: PacienteService) { }

  ngOnInit() {
    this. get();
  }
  
  update() {
    Swal.fire({
      title: 'Estas seguro?',
      text: "Deseas Modificar",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Aceptar'
    }).then((result) => {
      if (result.isConfirmed) {
        this.service.put(this.paciente).subscribe(p => {
          
          Swal.fire(
            '',
            'Registro Modificado!',
            'success'
          )
          this.get();
        }); 
      }
    }) 
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

  Cancelar(){
    this.view = false;
  }

  onSearch(id: string){
    this.service.getId(id).subscribe(result => {
      this.paciente = result;
    });
  }
}
