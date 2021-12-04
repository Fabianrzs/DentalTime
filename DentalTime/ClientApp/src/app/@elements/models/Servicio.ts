import { DetalleServicio } from "./DetalleServicio";

export class Servicio {
    nombre: string;
    precio: number;
    duracion: string;
}

export class ServicioView extends Servicio {
    idServico:number;
    detalleServicio: DetalleServicio[];

}