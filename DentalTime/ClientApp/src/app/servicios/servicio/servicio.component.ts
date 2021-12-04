import { Component, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatPaginator } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { Servicio } from "src/app/@elements/models/Servicio";
import { ServicioService } from "src/app/@elements/service/servicio.service";
import Swal from "sweetalert2";
import { AlertModalComponent } from "../../@base/alertModal/alertModal.component";
import { SignalRService } from "../../@elements/service/SignalR.service";
@Component({
  selector: "app-servicio",
  templateUrl: "./servicio.component.html",
  styleUrls: ["./servicio.component.css"],
})
export class ServicioComponent implements OnInit {

  servicio: Servicio;
  servicios: MatTableDataSource<Servicio>;

  constructor(
    private service: ServicioService,
  ) {}
  
  displayedColumns: string[] = ['nombre', 'precio', 'duracion'];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isLinear = false;
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;

  ngOnInit() {
    this.get();
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.servicios.filter = filterValue.trim().toLowerCase();
  }

  get() {
    this.service.get().subscribe((result) => {
      this.servicios = new MatTableDataSource<Servicio>(result);
      this.servicios.paginator = this.paginator;
    });
  }

}
