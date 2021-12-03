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

  selectTipoDocumento = new FormControl('', Validators.required);
  selectTipoSanguineo = new FormControl('', Validators.required);
  noDocumento = new FormControl('', Validators.pattern('[0-9 ]*'));
  nombres = new FormControl('', Validators.pattern('[a-zA-Z ]*'));
  apellidos = new FormControl('', Validators.pattern('[a-zA-Z ]*'));
  fechaNacimiento = new FormControl(new Date());
  selectSexo = new FormControl('', Validators.required);
  lugarNacimiento = new FormControl('', Validators.pattern('[a-zA-Z ]*'));
  email = new FormControl('', [Validators.required, Validators.email]);
  numeroCelular = new FormControl('', Validators.pattern('[0-9 ]*'));

  paciente: Paciente;
  formPaciente: FormGroup;

  constructor(private service: PacienteService, private formBuilder: FormBuilder) { }

  ngOnInit() {

  }


  getErrorDocumento() {
    if (this.noDocumento.hasError('required')) {
      return 'Este campo es obligatorio‎';
    } else {
      if (this.noDocumento.hasValidator) {
        return 'Solo se aceptan numeros';
      }
    }
  }
  getErrorNombres() {
    if (this.nombres.hasError('required')) {
      return 'Este campo es obligatorio‎';
    } else {
      if (this.nombres.hasValidator) {
        return 'Solo se aceptan letras';
      }
    }
  }
  getErrorApellidos() {
    if (this.apellidos.hasError('required')) {
      return 'Este campo es obligatorio‎';
    } else {
      if (this.apellidos.hasValidator) {
        return 'Solo se aceptan letras';
      }
    }
  }

  getErrorLugarNacimiento() {
    if (this.lugarNacimiento.hasError('required')) {
      return 'Este campo es obligatorio‎';
    } else {
      if (this.lugarNacimiento.hasValidator) {
        return 'Solo se aceptan letras';
      }
    }
  }

  getErrorEmail() {
    if (this.email.hasError('required')) {
      return 'Este campo es obligatorio';
    }
    return this.email.hasError('email') ? 'No es un correo electronico valido' : '';
  }

  getErrorNumeroCelular() {
    if (this.noDocumento.hasError('required')) {
      return 'Este campo es obligatorio‎';
    } else {
      if (this.noDocumento.hasValidator) {
        return 'Solo se aceptan numeros';
      }
    }
  }

  add() {
    this.paciente = this.formPaciente.value;
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