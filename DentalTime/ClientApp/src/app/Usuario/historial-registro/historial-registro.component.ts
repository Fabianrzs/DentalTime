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

  constructor(private service: HistoriaOdontologicaService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.buildForm();
  }

  buildForm(){
    this.historia = new HistoriaOdontologica();

    this.historia.idHistoriaOdontologica = "";
    this.historia.noDocumentoPaciente = "";
    this.historia.fechaInicio = new Date;
    this.historia.idAntecedentes = "";
    this.historia.complicaciones = "";
    this.historia.enfermedades = "";
    this.historia.farmaceuticos = "";
    this.historia.quimicos = "";

    this.formHistoriaOdontologica = this.formBuilder.group({
      idHistoriaOdontologica: [this.historia.idHistoriaOdontologica, Validators.required],
      noDocumentoPaciente: [this.historia.noDocumentoPaciente, Validators.required],
      fechaInicio: [this.historia.fechaInicio, Validators.required],
      idAntecedentes: [this.historia.idAntecedentes, Validators.required],
      complicaciones: [this.historia.complicaciones, Validators.required],
      enfermedades: [this.historia.enfermedades, Validators.required],
      farmaceuticos: [this.historia.farmaceuticos, Validators.required],
      quimicos: [this.historia.quimicos, Validators.required],
    });

    alert(this.historia.idAntecedentes);
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
    this.historia = this.formHistoriaOdontologica.value;
    alert("Ay"+this.historia.idAntecedentes);
    this.service.post(this.historia).subscribe(result => {
      if (result != null) {
        alert('Historia Odontologica Guardada');
        alert(JSON.stringify(result));
        this.historia = result;
      } else {
        alert(JSON.stringify(result));
      }
    });
  }

  // cargarCampos(){
  //   this.historia.idHistoriaOdontologica = this.historia.noDocumentoPaciente;
  //   this.antecedente.idAntecedentes = this.historia.noDocumentoPaciente;
  // }

}
