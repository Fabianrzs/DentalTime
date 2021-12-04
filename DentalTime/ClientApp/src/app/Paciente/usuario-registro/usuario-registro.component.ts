import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Paciente } from 'src/app/@elements/models/Paciente';
import { PacienteService } from 'src/app/@elements/service/paciente.service';
import Swal from 'sweetalert2';




@Component({
  selector: 'app-usuario-registro',
  templateUrl: './usuario-registro.component.html',
  styleUrls: ['./usuario-registro.component.css'],
})
export class UsuarioRegistroComponent implements OnInit {

  paciente: Paciente;
  formPaciente: FormGroup;

  constructor(private service: PacienteService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.buildForm() 
  }
  private buildForm() {
    
    this.formPaciente = this.formBuilder.group({
      selectTipoDocumento: ['', Validators.required],
      selectTipoSanguineo: ['', Validators.required,],
      noDocumento:['', Validators.pattern('[0-9 ]*')],
      nombres:['', Validators.pattern('[a-zA-Z ]*')],
      apellidos:['', Validators.pattern('[a-zA-Z ]*')],
      fechaNacimiento:['', Validators.required],
      selectSexo:['', Validators.required],
      lugarNacimiento:['', Validators.pattern('[a-zA-Z ]*')],
      email:['', [Validators.required, Validators.email]],
      numeroCelular:['', Validators.pattern('[0-9 ]*')]
    });
  }
  get control() { return this.formPaciente.controls; }
  onSubmit() {
    if (this.formPaciente.invalid) {
      alert(JSON.stringify(this.paciente))
      // (document.getElementById('guardar') as HTMLInputElement).disabled = true;
      return;
    }
    // (document.getElementById('guardar') as HTMLInputElement).disabled = false;
    this.add();
  }

  add() {
    this.paciente = new Paciente();
    this.paciente.sexo = this.formPaciente.value.selectSexo;
    this.paciente.tipoDocumento = this.formPaciente.value.selectTipoDocumento;
    this.paciente.tipoSanguineo = this.formPaciente.value.selectTipoSanguineo;
    this.paciente.numeroTelefonico = this.formPaciente.value.numeroCelular;
    this.paciente.correoElectronico = this.formPaciente.value.email;
    this.paciente.nombres = this.formPaciente.value.nombres;
    this.paciente.noDocumento = this.formPaciente.value.noDocumento;
    this.paciente.fechaNacimiento = this.formPaciente.value.fechaNacimiento;
    this.paciente.lugarNacimiento = this.formPaciente.value.lugarNacimiento;
    this.paciente.apellidos = this.formPaciente.value.apellidos;
    
    this.service.post(this.paciente).subscribe(result => {
      if (result != null) {
        Swal.fire(
          '',
          'Registro Exitoso',
          'success'
        )
        
      }
    });
  }

}
























// @Component({
//   selector: 'app-usuario-registro',
//   templateUrl: './usuario-registro.component.html',
//   styleUrls: ['./usuario-registro.component.css']
// })
// export class UsuarioRegistroComponent implements OnInit {

//   selectFormControl = new FormControl('', Validators.required);
//   noDocumentoFormControl = new FormControl('', Validators.required);






//   formPaciente: FormGroup;
//   paciente: Paciente;
//   constructor(private service: PacienteService, private formBuilder: FormBuilder) { }

//   ngOnInit() {
//     this.buildForm();

//   }

//   buildForm() {

//     this.paciente = new Paciente();

//     this.paciente.tipoDocumento = '';
//     this.paciente.noDocumento = '';
//     this.paciente.nombres = '';
//     this.paciente.apellidos = '';
//     this.paciente.sexo = '';
//     this.paciente.tipoSanguineo = '';
//     this.paciente.fechaNacimiento = new Date;
//     this.paciente.lugarNacimiento = '';
//     this.paciente.correoElectronico = '';
//     this.paciente.numeroTelefonico = '';

//     this.formPaciente = this.formBuilder.group({
//       tipoDocumento: [this.paciente.tipoDocumento, Validators.required],
//       noDocumento: [this.paciente.noDocumento, Validators.required],
//       nombres: [this.paciente.nombres, Validators.required],
//       apellidos: [this.paciente.apellidos, Validators.required],
//       sexo: [this.paciente.sexo, Validators.required],
//       tipoSanguineo: [this.paciente.tipoSanguineo, Validators.required],
//       fechaNacimiento: [this.paciente.fechaNacimiento, Validators.required],
//       lugarNacimiento: [this.paciente.lugarNacimiento, Validators.required],
//       correoElectronico: [this.paciente.correoElectronico, Validators.required],
//       numeroTelefonico: [this.paciente.numeroTelefonico, Validators.required],
//     });
//   }

//   get control() {
//     return this.formPaciente.controls;
//   }

//   onSubmit() {
//     if (this.formPaciente.invalid) {
//       Swal.fire({
//         icon: 'error',
//         text: 'Verifique los Campos',
//       })
//       return;
//     }
//     this.add();
//   }
//   add() {
//     this.paciente = this.formPaciente.value;
//     this.service.post(this.paciente).subscribe(result => {
//       if (result != null) {
//         Swal.fire(
//           '',
//           'Registro Exitoso',
//           'success'
//         )
//         this.clearCampos();
//       }
//     });
//   }

//   clearCampos() {
//     this.paciente.tipoDocumento = 'Seleccionar';
//     this.paciente.noDocumento = '';
//     this.paciente.nombres = '';
//     this.paciente.apellidos = '';
//     this.paciente.sexo = 'Seleccionar';
//     this.paciente.tipoSanguineo = '';
//     this.paciente.fechaNacimiento = new Date;
//     this.paciente.lugarNacimiento = '';
//     this.paciente.correoElectronico = '';
//     this.paciente.numeroTelefonico = '';

//     this.formPaciente = this.formBuilder.group({
//       tipoDocumento: [this.paciente.tipoDocumento, Validators.required],
//       noDocumento: [this.paciente.noDocumento, Validators.required],
//       nombres: [this.paciente.nombres, Validators.required],
//       apellidos: [this.paciente.apellidos, Validators.required],
//       sexo: [this.paciente.sexo, Validators.required],
//       tipoSanguineo: [this.paciente.tipoSanguineo, Validators.required],
//       fechaNacimiento: [this.paciente.fechaNacimiento, Validators.required],
//       lugarNacimiento: [this.paciente.lugarNacimiento, Validators.required],
//       correoElectronico: [this.paciente.correoElectronico, Validators.required],
//       numeroTelefonico: [this.paciente.numeroTelefonico, Validators.required],
//     });
//   }
// }