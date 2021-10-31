import { Component, OnInit } from '@angular/core';
import { Antecedente } from 'src/app/models/Antecedente';
import { HistoriaOdontologica } from 'src/app/models/HistoriaOdontologica';
import { HistoriaOdontologicaService } from 'src/app/service/historiaOdontologica.service';

@Component({
  selector: 'app-historial-registro',
  templateUrl: './historial-registro.component.html',
  styleUrls: ['./historial-registro.component.css']
})
export class HistorialRegistroComponent implements OnInit {


  historia: HistoriaOdontologica;
  antecedente: Antecedente;

  constructor(private service: HistoriaOdontologicaService) { }

  ngOnInit() {
    this.historia = new HistoriaOdontologica();
    this.antecedente = new Antecedente();
  }

  add() {

    this.historia.antecedente = this.antecedente;

    this.service.post(this.historia).subscribe(result => {
      if (result != null) {
        alert('Paciente Guardado');
        this.historia = result;
      }
    });
  }

}
