import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ConsultaOdontologica } from 'src/app/@elements/models/ConsultaOdontologica';
import { ConsultaOdontologicaViewModel } from 'src/app/@elements/models/ConsultaOdontologicaViewModel';
import { HistoriaOdontologica } from 'src/app/@elements/models/HistoriaOdontologica';
import { Paciente } from 'src/app/@elements/models/Paciente';
import { ConsultaOdontologicaService } from 'src/app/@elements/service/ConsultaOdontologica.service';
import { HistoriaOdontologicaService } from 'src/app/@elements/service/historiaOdontologica.service';
import { PacienteService } from 'src/app/@elements/service/paciente.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-historial-clinico',
  templateUrl: './historial-clinico.component.html',
  styleUrls: ['./historial-clinico.component.css']
})

export class HistorialClinicoComponent implements OnInit {

  consultaOdontologica: ConsultaOdontologicaViewModel[];
  historia: HistoriaOdontologica = new HistoriaOdontologica();
  paciente: Paciente = new Paciente();
  consultas: ConsultaOdontologica[];
  CONSULTAS: ConsultaOdontologica[];
  page = 1;
  pageSize = 4;
  collectionSize = 0;
  servicePaciente: any;

  constructor(private pacienteService: PacienteService, 
    private serviceHistoria: HistoriaOdontologicaService, 
    private consultaService: ConsultaOdontologicaService,
    private rutaActiva: ActivatedRoute) { }

  ngOnInit() {
    const noDocumentoPaciente = this.rutaActiva.snapshot.params.noDocumentoPaciente;
    alert(noDocumentoPaciente);
    this.findPaciente(noDocumentoPaciente);
    this.findHistoria(noDocumentoPaciente);
    this.findConsulta(noDocumentoPaciente);
  }

  findPaciente(noDocumentoPaciente: string) {
    this.pacienteService.getId(noDocumentoPaciente).subscribe(result => {
      this.paciente = result;
    });
  }

  findHistoria(noDocumentoPaciente: string) {
    this.serviceHistoria.getId(noDocumentoPaciente).subscribe(result => {
      this.historia = result;
      
      if(this.historia == null) {
        Swal.fire({
          icon: 'info',
          text: 'Historia Odontologica No Iniciada anteriormente, \n precione cancelar para volver',
        });
      }
    });
  }

  findConsulta(noDocumentoPaciente: string) {
    this.consultaService.getId(noDocumentoPaciente).subscribe(result => {
      this.consultaOdontologica = result;
      alert(JSON.stringify(this.consultaOdontologica));
    });
  }

  onSearch(){

  }

  get() {

  }

}
