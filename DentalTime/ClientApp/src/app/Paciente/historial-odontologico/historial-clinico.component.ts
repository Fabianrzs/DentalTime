import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ConsultaOdontologica } from 'src/app/@elements/models/ConsultaOdontologica';
import { Paciente } from 'src/app/@elements/models/Paciente';
import { PacienteService } from 'src/app/@elements/service/paciente.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-historial-clinico',
  templateUrl: './historial-clinico.component.html',
  styleUrls: ['./historial-clinico.component.css']
})

export class HistorialClinicoComponent implements OnInit {

  paciente: Paciente = new Paciente();
  consultas: ConsultaOdontologica[];
  CONSULTAS: ConsultaOdontologica[];
  page = 1;
  pageSize = 4;
  collectionSize = 0;
  servicePaciente: any;

  constructor(private pacienteService: PacienteService,
    private rutaActiva: ActivatedRoute) { }

  ngOnInit() {
    const noDocumentoPaciente = this.rutaActiva.snapshot.params.noDocumentoPaciente;
    alert(noDocumentoPaciente);
    this.findPaciente(noDocumentoPaciente);
  }

  findPaciente(noDocumentoPaciente: string) {
    this.pacienteService.getId(noDocumentoPaciente).subscribe(result => {
      this.paciente = result;
    });
  }

}
