import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConsultaOdontologica } from 'src/app/@elements/models/ConsultaOdontologica';
import { Paciente } from 'src/app/@elements/models/Paciente';
import { ConsultaOdontologicaService } from 'src/app/@elements/service/ConsultaOdontologica.service';
import { PacienteService } from 'src/app/@elements/service/paciente.service';

@Component({
  selector: 'app-consulta-registro',
  templateUrl: './consulta-registro.component.html',
  styleUrls: ['./consulta-registro.component.css']
})
export class ConsultaRegistroComponent implements OnInit {

  paciente: Paciente = new Paciente();
  consulta:ConsultaOdontologica = new ConsultaOdontologica();

  constructor(private pacienteService: PacienteService, 
    private rutaActiva: ActivatedRoute,
    private consultaService: ConsultaOdontologicaService) { }

  ngOnInit(): void {
    const noDocumentoPaciente = this.rutaActiva.snapshot.params.noDocumentoPaciente;
    this.findPaciente(noDocumentoPaciente);
  }

  findPaciente(noDocumentoPaciente: string) {
    this.pacienteService.getId(noDocumentoPaciente).subscribe(result => {
      this.paciente = result;
    });
  }

  add(){
    this.consulta.idHistoriaOdontologica = this.paciente.noDocumento;
    this.consultaService.post(this.consulta).subscribe(result => {
      this.consulta = result;
    });
  }

}
