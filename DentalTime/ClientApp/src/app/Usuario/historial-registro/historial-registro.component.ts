import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Antecedente } from 'src/app/models/Antecedente';
import { HistoriaOdontologica } from 'src/app/models/HistoriaOdontologica';
import { HistoriaOdontologicaService } from 'src/app/service/historiaOdontologica.service';
@Component({
  selector: 'app-historial-registro',
  templateUrl: './historial-registro.component.html',
  styleUrls: ['./historial-registro.component.css']
})
export class HistorialRegistroComponent implements OnInit {

  formHistoriaOdontologica: FormGroup;
  historia: HistoriaOdontologica;
  antecedente: Antecedente;

  constructor(private service: HistoriaOdontologicaService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.buildForm();
  }

  buildForm(){
    this.historia = new HistoriaOdontologica();
    this.antecedente = new Antecedente();

    this.historia.idHistoriaOdontologica = "";
    this.historia.noDocumentoPaciente = "";
    this.historia.fechaInicio = new Date;
    this.antecedente.idAntecedentes = "";
    this.antecedente.complicaciones = "";
    this.antecedente.enfermedades = "";
    this.antecedente.farmaceuticos = "";
    this.antecedente.quimicos = "";

    this.formHistoriaOdontologica = this.formBuilder.group({
      idHistoriaOdontologica: [this.historia.idHistoriaOdontologica, Validators.required],
      noDocumentoPaciente: [this.historia.noDocumentoPaciente, Validators.required],
      fechaInicio: [this.historia.fechaInicio, Validators.required],
      idAntecedentes: [this.antecedente.idAntecedentes, Validators.required],
      complicaciones: [this.antecedente.complicaciones, Validators.required],
      enfermedades: [this.antecedente.enfermedades, Validators.required],
      farmaceuticos: [this.antecedente.farmaceuticos, Validators.required],
      quimicos: [this.antecedente.quimicos, Validators.required],
    });
  }

  get control(){
    return this.formHistoriaOdontologica.controls;
  }

  onSubmit(){
    if(this.formHistoriaOdontologica.invalid){
      alert("Informacion Invalida");
      return;
    }
    this.add();
  }

  add() {
    this.historia.antecedente = this.antecedente;
    this.service.post(this.historia).subscribe(result => {
      if (result != null) {
        alert('Historia Odontologica Guardada');
        this.historia = result;
      }
    });
  }

  // cargarCampos(){
  //   this.historia.idHistoriaOdontologica = this.historia.noDocumentoPaciente;
  //   this.antecedente.idAntecedentes = this.historia.noDocumentoPaciente;
  // }

}
