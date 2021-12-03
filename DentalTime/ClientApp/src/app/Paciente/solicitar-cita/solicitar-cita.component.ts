import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { DialogSolicitarCitaComponent } from 'src/app/@base/dialog-solicitar-cita/dialog-solicitar-cita.component';
import { AgendaView, FiltroInputModel } from 'src/app/@elements/models/agendaMedico';
import { Odontologo } from 'src/app/@elements/models/Odontologo';
import { AgendaMedicoService } from 'src/app/@elements/service/agendaMedico.service';
import { OdontologoService } from 'src/app/@elements/service/Odontologo.service';

@Component({
  selector: 'app-solicitar-cita',
  templateUrl: './solicitar-cita.component.html',
  styleUrls: ['./solicitar-cita.component.css']
})
export class SolicitarCitaComponent implements OnInit {

  agendaMedico: MatTableDataSource<AgendaView>;
  odontologos: Odontologo[];
  date:Date;
  documento:String;
  displayedColumns: string[] = ['codAgenda', 'estado', 'fechaFinal', 'fechaInicio'];
  constructor( private serviceAgenda: AgendaMedicoService,
    private service:OdontologoService,
    public dialog: MatDialog
  ) { }
  clickedRows = new Set<AgendaView>();
  @ViewChild(MatPaginator) paginator: MatPaginator;
  ngOnInit() {

    this.service.get().subscribe(result => {
      this.odontologos = result;
    });
  }

  consultarAgendas(odontologos:Odontologo)
  {
    this.documento = odontologos.noDocumento;
    this.serviceAgenda.get(odontologos.noDocumento).subscribe((result)=>{
      this.agendaMedico = new MatTableDataSource<AgendaView>(result);
      this.agendaMedico.paginator =  this.paginator;
    })
  }

  control = new FormControl('', Validators.required);
  selectFormControl = new FormControl('', Validators.required);

  openDialog(agenda: AgendaView): void {
    const dialogRef = this.dialog.open(DialogSolicitarCitaComponent, {
      width: '250px',
      height: '150px',
      data : agenda,    
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.agendaMedico.filter = filterValue.trim().toLowerCase();
  }

  consultar()
  {
    
  }
  addEvent() {
    const filtro = new FiltroInputModel;
    filtro.documento = this.documento;
    filtro.fecha = this.date;
    this.serviceAgenda.postFiltro(filtro).subscribe((result)=>{
      this.agendaMedico = new MatTableDataSource<AgendaView>(result);
      this.agendaMedico.paginator =  this.paginator;
    })
  }

}
