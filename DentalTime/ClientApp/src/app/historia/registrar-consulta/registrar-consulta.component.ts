import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DialogRegistrarConsultaComponent } from 'src/app/@base/dialog-registrar-consulta/dialog-registrar-consulta.component';
import { SolicitudCita, SolicitudView } from 'src/app/@elements/models/SolicitudCita';
import { OdontologoService } from 'src/app/@elements/service/Odontologo.service';

@Component({
  selector: 'app-registrar-consulta',
  templateUrl: './registrar-consulta.component.html',
  styleUrls: ['./registrar-consulta.component.css']
})
export class RegistrarConsultaComponent implements OnInit {

  constructor(private service: OdontologoService,public dialog: MatDialog) { }
  displayedColumns: string[] = ['documento','idSolicitudCita', 'estado', 'fecha'];
  solicitudCita : SolicitudView[];
  clickedRows = new Set<SolicitudView>();

  ngOnInit() {
    this.consultarCitaOdontologo();
  }

  consultarCitaOdontologo()
  {
    this.service.getId('1111').subscribe(data => {
      this.solicitudCita = data;
    })
  }

  openDialog(solicitudCita:SolicitudView){
  const dialogRef = this.dialog.open(DialogRegistrarConsultaComponent, {
    width: '1221px',
    height: '551px',
    data : solicitudCita,    
  });

}
}
