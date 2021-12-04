import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder} from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DialogConsultaPacienteComponent } from 'src/app/@base/dialog-consulta-paciente/dialog-consulta-paciente.component';
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
  displayedColumns: string[] = ['noDocumento', 'nombres', 'apellidos', 'sexo','numeroTelefonico', ];

  constructor(
    private service: PacienteService,
    private modal: NgbModal,private formBuilder: FormBuilder,
    private signalRService: SignalRService,
    public dialog: MatDialog) { 
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

  openDialog(paciente: PacienteView): void {
    const dialogRef = this.dialog.open(DialogConsultaPacienteComponent, {
      width: '900px',
      height: '420px',
      data : paciente,    
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
}
