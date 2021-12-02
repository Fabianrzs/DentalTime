import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alertModal/alertModal.component';
import { HistoriaOdontologica } from 'src/app/@elements/models/HistoriaOdontologica';
import { Paciente } from 'src/app/@elements/models/Paciente';
import { HistoriaOdontologicaService } from 'src/app/@elements/service/historiaOdontologica.service';
import { PacienteService } from 'src/app/@elements/service/paciente.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-historial-registro',
  templateUrl: './historial-registro.component.html',
  styleUrls: ['./historial-registro.component.css']
})
export class HistorialRegistroComponent implements OnInit {

  formHistoriaOdontologica: FormGroup;
  historia: HistoriaOdontologica = new HistoriaOdontologica();
  paciente: Paciente = new  Paciente();

  constructor(private modal: NgbModal,
    private serviceHistoria: HistoriaOdontologicaService,
    private servicePaciente: PacienteService,
    private formBuilder: FormBuilder, 
    private rutaActiva: ActivatedRoute) {}

  ngOnInit() {
    const noDocumentoPaciente = this.rutaActiva.snapshot.params.noDocumentoPaciente;
    this.findPaciente(noDocumentoPaciente);
    this.findHistoria(noDocumentoPaciente);
  }

  findPaciente(noDocumentoPaciente: string) {
    this.servicePaciente.getId(noDocumentoPaciente).subscribe(result => {
      this.paciente = result;
    });
  }

  findHistoria(noDocumentoPaciente: string) {
    this.serviceHistoria.getId(noDocumentoPaciente).subscribe(result => {
      this.historia = result;
      if(this.historia == null) {
        this.historia = new HistoriaOdontologica();
        this.buildForm();
        return ;
      }
      Swal.fire({
        icon: 'info',
        text: 'Historia Odontologica ya Iniciada anteriormente, \n precione cancelar para volver',
      });
      (document.getElementById('guardar') as HTMLInputElement).disabled = true;
    });
  }

  buildForm(){

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
    this.historia.noDocumentoPaciente = this.paciente.noDocumento;
    this.historia.idHistoriaOdontologica = this.paciente.noDocumento;
    this.historia.idAntecedente = this.paciente.noDocumento;
    
    this.serviceHistoria.post(this.historia).subscribe(result => {
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
}
