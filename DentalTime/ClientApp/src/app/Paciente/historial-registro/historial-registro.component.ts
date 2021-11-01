import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HistoriaOdontologica } from 'src/app/@elements/models/HistoriaOdontologica';
import { HistoriaOdontologicaService } from 'src/app/@elements/service/historiaOdontologica.service';
import Swal from 'sweetalert2';
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
    this.historia.idAntecedente = "";
    this.historia.complicaciones = "";
    this.historia.enfermedades = "";
    this.historia.farmaceuticos = "";
    this.historia.quimicos = "";

    this.formHistoriaOdontologica = this.formBuilder.group({
      idHistoriaOdontologica: [this.historia.idHistoriaOdontologica, Validators.required],
      noDocumentoPaciente: [this.historia.noDocumentoPaciente, Validators.required],
      fechaInicio: [this.historia.fechaInicio, Validators.required],
      idAntecedente: [this.historia.idAntecedente, Validators.required],
      complicaciones: [this.historia.complicaciones, Validators.required],
      enfermedades: [this.historia.enfermedades, Validators.required],
      farmaceuticos: [this.historia.farmaceuticos, Validators.required],
      quimicos: [this.historia.quimicos, Validators.required],
    });
  }

  get control(){
    return this.formHistoriaOdontologica.controls;
  }

  onSubmit(){
    
    if(this.formHistoriaOdontologica.invalid){
      Swal.fire({
        icon: 'error',
        text: 'Verifique los Campos',
      })
      return;
    }
    this.add();
  }

  add() {
    this.historia = this.formHistoriaOdontologica.value;
    this.service.post(this.historia).subscribe(result => {
      if (result != null) {
        if (result != null) {
          Swal.fire(
            'Registro Exitoso'
          )
          this.buildForm()
        }
      }
    });
  }

  // cargarCampos(){
  //   this.historia.idHistoriaOdontologica = this.historia.noDocumentoPaciente;
  //   this.antecedente.idAntecedentes = this.historia.noDocumentoPaciente;
  // }



}
