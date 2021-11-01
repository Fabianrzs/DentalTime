import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Servicio } from 'src/app/@elements/models/Servicio';
import { ServicioService } from 'src/app/@elements/service/servicio.service';
@Component({
  selector: 'app-servicio',
  templateUrl: './servicio.component.html',
  styleUrls: ['./servicio.component.css']
})
export class ServicioComponent implements OnInit {

  searchText: string;
  formServicio: FormGroup;
  servicio: Servicio;
  servicios: Servicio[];
  SERVICIOS: Servicio[];
  page = 1;
  pageSize = 3;
  collectionSize = 0;

  constructor(private service: ServicioService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.get();
    this.buildForm();
  }
  
  get() {  
    this.service.get().subscribe(result => {
      this.SERVICIOS = result;
      this.collectionSize = this.SERVICIOS.length;
      this.servicios = this.SERVICIOS
      .map((servicios, i) => ({id: i + 1, ...servicios}))
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
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
          alert('Informacion Validada');
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
        this.get();
      }
    });
  }
   
  clearCampos(){
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
}
