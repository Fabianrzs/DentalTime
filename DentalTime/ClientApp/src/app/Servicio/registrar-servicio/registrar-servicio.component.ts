import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Servicio } from 'src/app/models/Servicio';
import { ServicioService } from 'src/app/services/servicio.service';

@Component({
  selector: 'app-registrar-servicio',
  templateUrl: './registrar-servicio.component.html',
  styleUrls: ['./registrar-servicio.component.css']
})
export class RegistrarServicioComponent implements OnInit {

  searchText: string;
  formServicio: FormGroup;
  servicio: Servicio;
  servicios: Servicio[];

  constructor(private service: ServicioService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    //this.buildForm();
    //this.get();
  }
  
  get() {  
    this.service.get().subscribe(result => {
      this.servicios = result;
    });
  }

  buildForm() {
    this.servicio = new Servicio();
    this.servicio.idServico = '';
    this.servicio.nombre = '';
    this.servicio.precio = 0;
    this.servicio.duracion = '';
  
    this.formServicio = this.formBuilder.group({
      idServico: [this.servicio.idServico , Validators.required],
      nombre: [this.servicio.nombre , Validators.required],
      precio: [this.servicio.precio , Validators.required],
      duracion:[this.servicio.duracion , Validators.required],
    });
  }

  get control() { 
    return this.formServicio.controls;
  }

  onSubmit() {
        if (this.formServicio.invalid) {
          alert('Infromacion Validada');
          return;
        }
        this.add();
      }
  add() {
    this.servicio= this.formServicio.value;
    this.service.post(this.servicio).subscribe(result => {
      if(result != null) {
        alert('Servicio Guardado');
        this.servicio = result;
      }
    });
  }
   
  clearCampos(){
    this.servicio.idServico = '';
    this.servicio.nombre = '';
    this.servicio.precio = 0;
    this.servicio.duracion = '';
  }
}
