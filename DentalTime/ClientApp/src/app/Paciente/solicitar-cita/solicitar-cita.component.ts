import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { AgendaView } from 'src/app/@elements/models/agendaMedico';
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
  displayedColumns: string[] = ['codAgenda', 'estado', 'fechaFinal', 'fechaInicio'];
  constructor( private serviceAgenda: AgendaMedicoService,
    private service:OdontologoService
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
    this.serviceAgenda.get(odontologos.noDocumento).subscribe((result)=>{
      this.agendaMedico = new MatTableDataSource<AgendaView>(result);
      this.agendaMedico.paginator =  this.paginator;
    })
  }

  control = new FormControl('', Validators.required);
  selectFormControl = new FormControl('', Validators.required);

}
