import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AgendaView } from 'src/app/@elements/models/agendaMedico';
import { Odontologo } from 'src/app/@elements/models/Odontologo';
import { Paciente } from 'src/app/@elements/models/Paciente';
import { SolicitudCita, SolicitudView } from 'src/app/@elements/models/SolicitudCita';
import { PacienteService } from 'src/app/@elements/service/paciente.service';
import { SolicitudCitaService } from 'src/app/@elements/service/solicitudCita.service';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-dialog-solicitar-cita',
  templateUrl: './dialog-solicitar-cita.component.html',
  styleUrls: ['./dialog-solicitar-cita.component.css']
})
export class DialogSolicitarCitaComponent implements OnInit {

  paciente: Paciente;
  noDocumento:string;
  odontologo: Odontologo;
  citaView:SolicitudCita;
  constructor(private servicePaciente: PacienteService,private serviceCita:SolicitudCitaService,
    public dialogRef: MatDialogRef<DialogSolicitarCitaComponent>,
    @Inject(MAT_DIALOG_DATA) public data: AgendaView,
  ) {
    
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
  ngOnInit() {
    this.paciente = new Paciente;
    this.data.fechaHoraInicio
  }

  buscarPaciente(){
   
    this.servicePaciente.getId(this.noDocumento).subscribe((item)=>{
      this.paciente = item;
    })
  }
  guardarCita()
  {
    this.citaView = new SolicitudCita;
    this.citaView.codAgenda =  this.data.codAgenda;
    this.citaView.noDocumento = this.noDocumento;
    this.serviceCita.post(this.citaView).subscribe((item)=>{
      const cita = item;
      Swal.fire(
        '',
        'Registro Exitoso',
        'success'
      )
      this.dialogRef.close();
    })
  }
}
