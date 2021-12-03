import { Component, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatPaginator } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { Servicio } from "src/app/@elements/models/Servicio";
import { ServicioService } from "src/app/@elements/service/servicio.service";
import Swal from "sweetalert2";
import { AlertModalComponent } from "../@base/alertModal/alertModal.component";
import { SignalRService } from "../@elements/service/SignalR.service";
@Component({
  selector: "app-servicio",
  templateUrl: "./servicio.component.html",
  styleUrls: ["./servicio.component.css"],
})
export class ServicioComponent implements OnInit {
  searchText: string;
  formServicio: FormGroup;
  servicio: Servicio;
  
  servicios: Servicio[];
  SERVICIOS: MatTableDataSource<Servicio>;
  page = 1;
  pageSize = 3;
  collectionSize = 0;

  constructor(
    private service: ServicioService,
    private formBuilder: FormBuilder,
    private signalRService: SignalRService,
    private modal: NgbModal,
    private _formBuilder: FormBuilder
  ) {}
  displayedColumns: string[] = ['nombre', 'precio', 'duracion'];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isLinear = false;
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;

  ngOnInit() {
    this.get();
    this.buildForm();
    this.firstFormGroup = this._formBuilder.group({
      firstCtrl: ['', Validators.required],
    });
    this.secondFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required],
    });
  }



  get() {
    this.service.get().subscribe((result) => {
      this.SERVICIOS = new MatTableDataSource<Servicio>(result);
      this.SERVICIOS.paginator = this.paginator;
    });
    this.signalRService.signalReceived.subscribe((signal: Servicio) => {  
      this.servicios.push(signal)
    });
  }

  buildForm() {
    this.servicio = new Servicio();
    this.servicio.nombre = "";
    this.servicio.precio = 0;
    this.servicio.duracion = "";

    this.formServicio = this.formBuilder.group({
      nombre: [this.servicio.nombre, Validators.required],
      precio: [this.servicio.precio, Validators.required],
      duracion: [this.servicio.duracion, Validators.required],
    });
  }

  get control() {
    return this.formServicio.controls;
  }

  onSubmit() {
    if (this.formServicio.invalid) {
      Swal.fire({
        icon: "error",
        text: "Verifique los Campos",
      });
      return;
    }
    this.add();
  }
  add() {
    this.servicio = this.formServicio.value;
    this.service.post(this.servicio).subscribe((result) => {
      if (result != null) {
        /*Swal.fire("", "Registro Exitoso", "success");*/
        const messageBox = this.modal.open(AlertModalComponent);
        messageBox.componentInstance.title = "Resultado";
        messageBox.componentInstance.message =
          "Registro Guardado Satisfactoriamente";
        this.get();
      }
    });
  }
}
