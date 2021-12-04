import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder} from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PacienteView } from 'src/app/@elements/models/Paciente';
import { PacienteService } from 'src/app/@elements/service/paciente.service';;
import { SignalRService } from '../../@elements/service/SignalR.service';

@Component({
  selector: 'app-consultar-consultas',
  templateUrl: './consultar-consultas.component.html',
  styleUrls: ['./consultar-consultas.component.css']
})
export class ConsultarConsultasComponent implements OnInit {

  paciente: MatTableDataSource<PacienteView>;
  displayedColumns: string[] = ['identificacion', 'nombre', 'apellido', 'sexo', 'telefono', ];
  pacienteView:PacienteView;
  constructor(
    private service: PacienteService,
    private modal: NgbModal,private formBuilder: FormBuilder,
    private signalRService: SignalRService,) { 
    }
    clickedRows = new Set<PacienteView>();
    @ViewChild(MatPaginator) paginator: MatPaginator;
  ngOnInit() {
    this.consultarPacientes();
  }

  consultarPacientes()
  {
    this.service.get().subscribe((result)=>{
      this.paciente = new MatTableDataSource<PacienteView>(result);
      this.paciente.paginator =  this.paginator;
    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.paciente.filter = filterValue.trim().toLowerCase();
  }


}
