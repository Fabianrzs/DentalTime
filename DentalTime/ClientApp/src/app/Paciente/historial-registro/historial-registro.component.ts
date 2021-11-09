import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { find } from 'rxjs/operators';
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
  historiaBuscada: HistoriaOdontologica;

  constructor(private service: HistoriaOdontologicaService, private formBuilder: FormBuilder, private rutaActiva: ActivatedRoute) { }

  ngOnInit() {
    const noDocumentoPaciente = this.rutaActiva.snapshot.params.noDocumentoPaciente;
    this.find(noDocumentoPaciente);
    this.buildForm();
  }

  find(noDocumentoPaciente: string) {
    this.service.getId(noDocumentoPaciente).subscribe(result => {
      this.historiaBuscada = result;
      alert(noDocumentoPaciente);
      alert(JSON.stringify(result));

    });
  }

  buildForm(){
    this.historia = this.historiaBuscada;
    this.formHistoriaOdontologica = this.formBuilder.group({
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
