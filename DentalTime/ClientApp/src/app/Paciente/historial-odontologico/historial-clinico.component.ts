import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ConsultaOdontologica } from 'src/app/@elements/models/ConsultaOdontologica';
import { HistoriaOdontologica } from 'src/app/@elements/models/HistoriaOdontologica';
import { Paciente } from 'src/app/@elements/models/Paciente';
import { ConsultaOdontologicaService } from 'src/app/@elements/service/ConsultaOdontologica.service';
import { HistoriaOdontologicaService } from 'src/app/@elements/service/historiaOdontologica.service';
import { PacienteService } from 'src/app/@elements/service/paciente.service';

@Component({
  selector: 'app-historial-clinico',
  templateUrl: './historial-clinico.component.html',
  styleUrls: ['./historial-clinico.component.css']
})

export class HistorialClinicoComponent implements OnInit {


  historia: HistoriaOdontologica;
  paciente: Paciente;
  consultas: ConsultaOdontologica[];
  CONSULTAS: ConsultaOdontologica[];
  page = 1;
  pageSize = 4;
  collectionSize = 0;

  constructor(private pacienteService: PacienteService, 
    private historiaService: HistoriaOdontologicaService, 
    private consultaService: ConsultaOdontologicaService) { }

  ngOnInit() {
  }

  onSearch(){

  }

  get() {

  }

}
