import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Producto } from 'src/app/@elements/models/Producto';
import { ProductoService } from 'src/app/@elements/service/producto.service';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.css']
})
export class ProductoComponent implements OnInit {

  displayedColumns: string[] = ["referencia", "nombre", "laboratorio", "marca", "stockActual"];
  dataSource: MatTableDataSource<Producto>;

  constructor(private service: ProductoService) {}

  ngOnInit() {
    this.consultarProducto();
  }
  clickedRows = new Set<Producto>();
  @ViewChild(MatPaginator) paginator: MatPaginator;

  consultarProducto() {

    this.service.get().subscribe((result)=>{
    this.dataSource = new MatTableDataSource<Producto>(result);
    this.dataSource.paginator = this.paginator;
    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

}
