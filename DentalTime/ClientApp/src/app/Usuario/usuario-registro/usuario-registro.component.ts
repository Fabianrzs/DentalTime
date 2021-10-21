import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Paciente } from 'src/app/models/Paciente';
import { PacienteServiceService } from 'src/app/services/pacienteService.service';

@Component({
  selector: 'app-usuario-registro',
  templateUrl: './usuario-registro.component.html',
  styleUrls: ['./usuario-registro.component.css']
})
export class UsuarioRegistroComponent implements OnInit {

  formPaciente: FormGroup;
  paciente: Paciente;

  constructor(private service: PacienteServiceService, private formBuilder: FormBuilder) { }


  ngOnInit() {
    this.buildForm();
  }

  buildForm() {

    this.paciente = new Paciente();

    this.paciente.tipoDocumento = '';
    this.paciente.noDocumento = '';
    this.paciente.nombres = '';
    this.paciente.apellidos = '';
    this.paciente.sexo = '';
    this.paciente.tipoSanguineo = '';
    this.paciente.fechaNacimiento = new Date;
    this.paciente.LugarNacimiento = '';
    this.paciente.correoElectronico = '';
    this.paciente.numeroTelefonico = '';

    this.formPaciente = this.formBuilder.group({
      tipoDocumento: [this.paciente.tipoDocumento , Validators.required],
      noDocumento: [this.paciente.noDocumento , Validators.required],
      nombres: [this.paciente.nombres , Validators.required],
      apellidos:[this.paciente.apellidos , Validators.required],
      sexo: [this.paciente.sexo , Validators.required],
      tipoSanguineo:[this.paciente.tipoSanguineo , Validators.required],
      fechaNacimiento:[this.paciente.fechaNacimiento , Validators.required],
      LugarNacimiento:[this.paciente.LugarNacimiento , Validators.required],
      correoElectronico:[this.paciente.correoElectronico , Validators.required],
      numeroTelefonico:[this.paciente.numeroTelefonico , Validators.required],
    });
  }

  get control() { 
    return this.formPaciente.controls;
  }

  onSubmit() {
        if (this.formPaciente.invalid) {
          alert('Vaina invalida');
          return;
        }
        this.add();
      }
  add() {

    this.paciente= this.formPaciente.value;
    this.service.post(this.paciente).subscribe(result => {
      if(result != null) {
        alert('Paciente Guardado');
        this.paciente = result;
      }
    });
  }
   
  clearCampos(){
    this.paciente.tipoDocumento = 'Seleccionar';
    this.paciente.noDocumento = '';
    this.paciente.nombres = '';
    this.paciente.apellidos = '';
    this.paciente.sexo = 'Seleccionar';
    this.paciente.tipoSanguineo = '';
    this.paciente.fechaNacimiento = new Date;
    this.paciente.LugarNacimiento = '';
    this.paciente.correoElectronico = '';
    this.paciente.numeroTelefonico = '';
  }

}
