import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ConsultaOdontologica, ConsultaOdontologicaView } from 'src/app/@elements/models/ConsultaOdontologica';
import { Paciente, PacienteView } from 'src/app/@elements/models/Paciente';
import { ConsultaService } from 'src/app/@elements/service/consulta.service';
import { DialogRegistrarConsultaComponent } from '../dialog-registrar-consulta/dialog-registrar-consulta.component';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H'},
  {position: 2, name: 'Helium', weight: 4.0026, symbol: 'He'},
  {position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li'},
  {position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be'},
  {position: 5, name: 'Boron', weight: 10.811, symbol: 'B'},
  {position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C'},
  {position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N'},
  {position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O'},
  {position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F'},
  {position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne'},
];

@Component({
  selector: 'app-dialog-consulta-paciente',
  templateUrl: './dialog-consulta-paciente.component.html',
  styleUrls: ['./dialog-consulta-paciente.component.css']
})
export class DialogConsultaPacienteComponent implements OnInit {
   displayedColumns: string[] = [ 'motivo','medicacion', 'valoracion', 'receta'];
  consultas: MatTableDataSource<ConsultaOdontologicaView>;
  dataSource = ELEMENT_DATA;
  constructor(
    private service: ConsultaService,
    public dialogRef: MatDialogRef<DialogRegistrarConsultaComponent>,
    @Inject(MAT_DIALOG_DATA) public data: PacienteView,
  ) { }
  clickedRows = new Set<ConsultaOdontologicaView>();
  @ViewChild(MatPaginator) paginator: MatPaginator;
  ngOnInit() {
    this.consultas = new MatTableDataSource<ConsultaOdontologicaView>();
    this.get();
  }

  get() {
    this.service.getId(this.data.noDocumento).subscribe((item) => {
      this.consultas = new MatTableDataSource<ConsultaOdontologicaView>(item);
      this.consultas.paginator = this.paginator;
    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
   this.consultas.filter = filterValue.trim().toLowerCase();
  }

}
 