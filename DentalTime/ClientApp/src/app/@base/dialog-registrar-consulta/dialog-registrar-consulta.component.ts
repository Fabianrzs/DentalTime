import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Antecendentes } from 'src/app/@elements/models/Antecendentes';
import { ConsultaOdontologica } from 'src/app/@elements/models/ConsultaOdontologica';
import { SolicitudView } from 'src/app/@elements/models/SolicitudCita';

@Component({
  selector: 'app-dialog-registrar-consulta',
  templateUrl: './dialog-registrar-consulta.component.html',
  styleUrls: ['./dialog-registrar-consulta.component.css']
})
export class DialogRegistrarConsultaComponent implements OnInit {

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  isEditable = false;
  consulta:ConsultaOdontologica;
  Antecendentes:Antecendentes;
  constructor(private _formBuilder: FormBuilder,
    // public dialogRef: MatDialogRef<DialogRegistrarConsultaComponent>,
    // @Inject(MAT_DIALOG_DATA) public data: SolicitudView,
  ) {
    
  }
  ngOnInit(): void {
    this.buildfirstForm();
   this.buildSecondForm();
  }

  private buildfirstForm() {
    
    this.firstFormGroup = this._formBuilder.group({
      motivo: ['', Validators.required],
      medicacion: ['', Validators.required],
      diagnostico: ['', Validators.required],
      valoracion: ['', Validators.required]
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
  get controlSecond() { return this.secondFormGroup.controls; }
  }

  



