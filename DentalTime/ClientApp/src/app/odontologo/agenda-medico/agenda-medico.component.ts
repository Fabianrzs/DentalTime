import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AgendaMedico, AgendaView } from '../../@elements/models/agendaMedico';
import { AgendaMedicoService } from '../../@elements/service/agendaMedico.service';
import { SignalRService } from '../../@elements/service/SignalR.service';

@Component({
  selector: 'app-agenda-medico',
  templateUrl: './agenda-medico.component.html',
  styleUrls: ['./agenda-medico.component.css']
})
export class AgendaMedicoComponent implements OnInit {
  
  agendaMedico: MatTableDataSource<AgendaView>;
  displayedColumns: string[] = ['codAgenda', 'estado', 'fechaFinal', 'fechaInicio'];
  agenda: AgendaMedico;
  formGroup: FormGroup;
  agendaView:AgendaView;
  constructor(
    private service: AgendaMedicoService,
    private modal: NgbModal,private formBuilder: FormBuilder,
    private signalRService: SignalRService,) { 
    }
    clickedRows = new Set<AgendaView>();
    @ViewChild(MatPaginator) paginator: MatPaginator;
  ngOnInit() {
    this.consultarAgendas();
    this.buildForm() 
  }

  consultarAgendas()
  {
    this.service.get('1111').subscribe((result)=>{
      this.agendaMedico = new MatTableDataSource<AgendaView>(result);
      this.agendaMedico.paginator =  this.paginator;
    })
  }

  private buildForm() {
    
    this.formGroup = this.formBuilder.group({
      fechaInicio: ['', Validators.required],
      fechaFinal: ['', Validators.required,],
    });
  }
  get control() { return this.formGroup.controls; }

  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
  }

  add() {
    this.agenda = new AgendaMedico();
    this.agenda.fechaHoraInicio = this.formGroup.value.fechaInicio
    this.agenda.fechaHoraFin = this.formGroup.value.fechaFinal
    this.agenda.noDocumento = '1111';
   
    this.service.post(this.agenda).subscribe(x => {
      if (x != null) {
        this.buildForm();
        this.agendaView = x;
      }
    });
  }

}
