import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AgendaView } from 'src/app/@elements/models/agendaMedico';


@Component({
  selector: 'app-dialog-solicitar-cita',
  templateUrl: './dialog-solicitar-cita.component.html',
  styleUrls: ['./dialog-solicitar-cita.component.css']
})
export class DialogSolicitarCitaComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<DialogSolicitarCitaComponent>,
    @Inject(MAT_DIALOG_DATA) public data: AgendaView,
  ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
  ngOnInit() {
  }

}
