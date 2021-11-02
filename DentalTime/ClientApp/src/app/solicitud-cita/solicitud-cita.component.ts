import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';
import { SolicitudCita } from '../@elements/models/SolicitudCita';
import { SolicitudCitaService } from '../@elements/service/SolicitudCita.service';

@Component({
  selector: 'app-agendar-cita',
  templateUrl: './solicitud-cita.component.html',
  styleUrls: ['./solicitud-cita.component.css']
})
export class SolicitudCitaComponent implements OnInit {

  page = 1;
  pageSize = 4;
  collectionSize = 0;
  searchText: string;
  agendaCita: SolicitudCita;
  agendaCitas: SolicitudCita[];
  AGENDACITA: SolicitudCita[];

  constructor(private service: SolicitudCitaService) { }

  ngOnInit() {
    this.agendaCita = new SolicitudCita();
    this.get();
  }

  get() {
    this.service.get().subscribe(result => {

      this.AGENDACITA = result
      this.collectionSize = this.AGENDACITA.length;
      this.agendaCitas = this.AGENDACITA
        .map((servicios, i) => ({ id: i + 1, ...servicios }))
        .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
    });
  }

  onSearch(id: number) {
    this.service.getId(id).subscribe(result => {
      this.agendaCita = result;
      this.get();
    });
  }

  add() {
    this.service.post(this.agendaCita).subscribe(result => {
      if (result != null) {
        Swal.fire(
          '',
          'Registro Exitoso',
          'success'
          
        );
        this.instancias();
        this.get();
      }
    });
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
        this.service.put(this.agendaCita).subscribe(p => {
          if(p != null) {
            Swal.fire(
              '',
              'Registro Modificado!',
              'success'
            );this.get();
          } 
        });
      }
    })
  }

  instancias() {
    this.agendaCita = new SolicitudCita();
  }
}

