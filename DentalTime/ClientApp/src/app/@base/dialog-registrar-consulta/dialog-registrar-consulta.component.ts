import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Antecendentes } from 'src/app/@elements/models/Antecendentes';
import { ConsultaOdontologica } from 'src/app/@elements/models/ConsultaOdontologica';
import { Odontologo } from 'src/app/@elements/models/Odontologo';
import { Paciente } from 'src/app/@elements/models/Paciente';
import { Servicio, ServicioView } from 'src/app/@elements/models/Servicio';
import { SolicitudView } from 'src/app/@elements/models/SolicitudCita';
import { ConsultaService } from 'src/app/@elements/service/consulta.service';
import { ServicioService } from 'src/app/@elements/service/servicio.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-dialog-registrar-consulta',
  templateUrl: './dialog-registrar-consulta.component.html',
  styleUrls: ['./dialog-registrar-consulta.component.css']
})
export class DialogRegistrarConsultaComponent implements OnInit {
  noDocumento:string;
  odontologo: Odontologo;
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  isEditable = false;
  consulta:ConsultaOdontologica;
  Antecendentes:Antecendentes;
  paciente: Paciente;
  servicios:ServicioView[];
  servi: ServicioView;
  constructor(private _formBuilder: FormBuilder,private Service: ServicioService,private consultaService: ConsultaService,
    public dialogRef: MatDialogRef<DialogRegistrarConsultaComponent>,
    @Inject(MAT_DIALOG_DATA) public data: SolicitudView,
  ) {
    
  }
  ngOnInit(): void {
    this.servi = new ServicioView;
    this.paciente = this.data.paciente;
    this.buildfirstForm();
   this.buildSecondForm();
   this.consultarServicio();
  }

  private buildfirstForm() {
    
    this.firstFormGroup = this._formBuilder.group({
      motivo: ['', Validators.required],
      medicacion: ['', Validators.required],
      diagnostico: ['', Validators.required],
      valoracion: ['', Validators.required],
      recetaMedica:['', Validators.required],
    });
  }
  get controlfirst() { return this.firstFormGroup.controls; }

  private buildSecondForm() {
    
    this.secondFormGroup = this._formBuilder.group({
      enfermedades: ['', Validators.required],
      farmaceuticos: ['', Validators.required],
      quimicos: ['', Validators.required],
      complicaciones: ['', Validators.required]
    });
  }
  onSubmit() {

    if (this.firstFormGroup.invalid && this.secondFormGroup.invalid) {
      
      return;
    }
    this.add();
  }
  add() {
    
    this.consulta = new ConsultaOdontologica;
    this.Antecendentes = new Antecendentes;
    this.Antecendentes.enfermedades = this.secondFormGroup.value.enfermedades;
    this.Antecendentes.complicaciones = this.secondFormGroup.value.complicaciones;
    this.Antecendentes.farmaceuticos = this.secondFormGroup.value.farmaceuticos;
    this.Antecendentes.quimicos = this.secondFormGroup.value.quimicos;
    this.consulta.motivo = this.firstFormGroup.value.motivo;
    this.consulta.medicacion = this.firstFormGroup.value.medicacion;
    this.consulta.diagnostico = this.firstFormGroup.value.diagnostico;
    this.consulta.valoracion = this.firstFormGroup.value.valoracion;
    this.consulta.recetaMedica = this.firstFormGroup.value.recetaMedica;
    this.consulta.antecedente =this.Antecendentes;
    this.consulta.noDocumento = this.paciente.noDocumento;
    this.consulta.idSolicitudCita = this.data.idSolicitudCita;
    this.consulta.IdServicio = this.servi.idServico;
    alert(JSON.stringify(this.Antecendentes))
    this.consultaService.post(this.consulta).subscribe(item=>{
      if (item) {
        Swal.fire(
          '',
          'Registro Exitoso',
          'success'
        )
      }
    })


  }
  get controlSecond() { return this.secondFormGroup.controls; }
  consultarServicio()
  {
    this.Service.get().subscribe(item => {
      this.servicios = item;

    })
  } 
  escogerServicio(service:ServicioView){
    this.servi = service;
  } 
}

  

