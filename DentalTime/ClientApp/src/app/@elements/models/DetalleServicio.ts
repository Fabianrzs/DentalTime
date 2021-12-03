import { Producto } from "./Producto";
import { Servicio } from "./Servicio";

export class DetalleServicio {

    referenciaProducto: string;
    idServicio: number;
    unidades: number;

}

export class DetalleServicioView extends DetalleServicio{
    
    IdDetalleServicio: number;
    producto:Producto;
    servicio:Servicio;

}
