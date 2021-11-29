import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from '../@base/alertModal/alertModal.component';
import { AgendaMedico } from '../@elements/models/agendaMedico';
import { AgendaMedicoService } from '../@elements/service/agendaMedico.service';
import { SignalRService } from '../@elements/service/SignalR.service';

@Component({
  selector: 'app-agenda-medico',
  templateUrl: './agenda-medico.component.html',
  styleUrls: ['./agenda-medico.component.css']
})
export class AgendaMedicoComponent implements OnInit {

  searchText: string;
  agendaMedico: AgendaMedico;
  agendasMedicas: AgendaMedico[];
  AGENDASMMEDICAS: AgendaMedico[];
  page = 1;
  pageSize = 3;
  collectionSize = 0;

  constructor(
    private service: AgendaMedicoService,
    private modal: NgbModal,
    private signalRService: SignalRService,) { }

  ngOnInit() {
    this.agendaMedico = new AgendaMedico();
    this.get();
  }

  get() {
    this.service.get().subscribe((result) => {
      this.AGENDASMMEDICAS = result;
      this.collectionSize = this.AGENDASMMEDICAS.length;
      this.agendasMedicas = this.AGENDASMMEDICAS.map((servicios, i) => ({
        id: i + 1,
        ...servicios,
      })).slice(
        (this.page - 1) * this.pageSize,
        (this.page - 1) * this.pageSize + this.pageSize
      );
    });
    this.signalRService.signalReceived.subscribe((signal: AgendaMedico) => {  
      this.agendasMedicas.push(signal)
    });
  }

  add() {
    this.service.post(this.agendaMedico).subscribe((result) => {
      if (result != null) {
        const messageBox = this.modal.open(AlertModalComponent);
        messageBox.componentInstance.title = "Resultado";
        messageBox.componentInstance.message = "Registro Guardado Satisfactoriamente";
        this.get();
      }
    });
  }

}
