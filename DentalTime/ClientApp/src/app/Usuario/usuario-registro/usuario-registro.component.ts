import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Paciente } from 'src/app/models/Paciente';
<<<<<<< HEAD
import { PacienteService } from 'src/app/service/paciente.service';

=======
import { PacienteService } from 'src/app/services/paciente.service';
>>>>>>> 46b6a98727ca27e29a9701e0ebf2ce521f31d793

@Component({
  selector: 'app-usuario-registro',
  templateUrl: './usuario-registro.component.html',
  styleUrls: ['./usuario-registro.component.css']
})
export class UsuarioRegistroComponent implements OnInit {

  formPaciente: FormGroup;
  paciente: Paciente;

  constructor(private service: PacienteService, private formBuilder: FormBuilder) { }
<<<<<<< HEAD
=======

>>>>>>> 46b6a98727ca27e29a9701e0ebf2ce521f31d793

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
<<<<<<< HEAD
    this.paciente.lugarNacimiento = '';
=======
    this.paciente.LugarNacimiento = '';
>>>>>>> 46b6a98727ca27e29a9701e0ebf2ce521f31d793
    this.paciente.correoElectronico = '';
    this.paciente.numeroTelefonico = '';

    this.formPaciente = this.formBuilder.group({
<<<<<<< HEAD
      tipoDocumento: [this.paciente.tipoDocumento, Validators.required],
      noDocumento: [this.paciente.noDocumento, Validators.required],
      nombres: [this.paciente.nombres, Validators.required],
      apellidos: [this.paciente.apellidos, Validators.required],
      sexo: [this.paciente.sexo, Validators.required],
      tipoSanguineo: [this.paciente.tipoSanguineo, Validators.required],
      fechaNacimiento: [this.paciente.fechaNacimiento, Validators.required],
      lugarNacimiento: [this.paciente.lugarNacimiento, Validators.required],
      correoElectronico: [this.paciente.correoElectronico, Validators.required],
      numeroTelefonico: [this.paciente.numeroTelefonico, Validators.required],
    });
  }

  get control() {
    return this.formPaciente.controls;
  }

  onSubmit() {
    if (this.formPaciente.invalid) {
      alert('Infromacion Validada');
      return;
    }
    this.add();
  }
  add() {

    this.paciente = this.formPaciente.value;
    this.service.post(this.paciente).subscribe(result => {
      if (result != null) {
=======
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
          alert('Infromacion Validada');
          return;
        }
        this.add();
      }
  add() {

    this.paciente= this.formPaciente.value;
    this.service.post(this.paciente).subscribe(result => {
      if(result != null) {
>>>>>>> 46b6a98727ca27e29a9701e0ebf2ce521f31d793
        alert('Paciente Guardado');
        this.paciente = result;
      }
    });
  }
<<<<<<< HEAD

  clearCampos() {
=======
   
  clearCampos(){
>>>>>>> 46b6a98727ca27e29a9701e0ebf2ce521f31d793
    this.paciente.tipoDocumento = 'Seleccionar';
    this.paciente.noDocumento = '';
    this.paciente.nombres = '';
    this.paciente.apellidos = '';
    this.paciente.sexo = 'Seleccionar';
    this.paciente.tipoSanguineo = '';
    this.paciente.fechaNacimiento = new Date;
<<<<<<< HEAD
    this.paciente.lugarNacimiento = '';
    this.paciente.correoElectronico = '';
    this.paciente.numeroTelefonico = '';

    this.formPaciente = this.formBuilder.group({
      tipoDocumento: [this.paciente.tipoDocumento, Validators.required],
      noDocumento: [this.paciente.noDocumento, Validators.required],
      nombres: [this.paciente.nombres, Validators.required],
      apellidos: [this.paciente.apellidos, Validators.required],
      sexo: [this.paciente.sexo, Validators.required],
      tipoSanguineo: [this.paciente.tipoSanguineo, Validators.required],
      fechaNacimiento: [this.paciente.fechaNacimiento, Validators.required],
      lugarNacimiento: [this.paciente.lugarNacimiento, Validators.required],
      correoElectronico: [this.paciente.correoElectronico, Validators.required],
      numeroTelefonico: [this.paciente.numeroTelefonico, Validators.required],
    });
=======
    this.paciente.LugarNacimiento = '';
    this.paciente.correoElectronico = '';
    this.paciente.numeroTelefonico = '';
  }

}
