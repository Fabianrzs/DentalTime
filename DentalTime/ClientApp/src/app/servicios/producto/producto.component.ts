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
  productos: Producto[];

  constructor(private service: ProductoService) {}

  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngOnInit() {
    this.consultarProducto();
  }


  consultarProducto() {

    this.service.get().subscribe((result)=>{
    this.dataSource = new MatTableDataSource<Producto>(result);
    this.dataSource.paginator = this.paginator;
    })
  }

  

}
