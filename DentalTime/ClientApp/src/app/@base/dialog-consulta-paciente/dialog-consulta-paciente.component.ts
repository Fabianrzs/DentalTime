import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ConsultaOdontologica, ConsultaOdontologicaView } from 'src/app/@elements/models/ConsultaOdontologica';
import { Paciente, PacienteView } from 'src/app/@elements/models/Paciente';
import { ConsultaService } from 'src/app/@elements/service/consulta.service';
import { DialogRegistrarConsultaComponent } from '../dialog-registrar-consulta/dialog-registrar-consulta.component';

@Component({
  selector: 'app-dialog-consulta-paciente',
  templateUrl: './dialog-consulta-paciente.component.html',
  styleUrls: ['./dialog-consulta-paciente.component.css']
})
export class DialogConsultaPacienteComponent implements OnInit {
  displayedColumns: string[] = ['fecha', 'motivo', 'medicacion', 'valoracion, recetaMedica'];
  //Click Se baja un desplegable que muestra los antecedentes
  consultas: MatTableDataSource<ConsultaOdontologica>;
  constructor(
    private service: ConsultaService,
    public dialogRef: MatDialogRef<DialogRegistrarConsultaComponent>,
    @Inject(MAT_DIALOG_DATA) public data: PacienteView,
  ) { }

  ngOnInit() {
    this.get();
  }

  get() {
    this.consultas = new MatTableDataSource<ConsultaOdontologica>(this.data.consultasOdontologicas)
  }

}
 