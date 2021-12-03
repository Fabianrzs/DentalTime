import { Odontologo } from "./Odontologo";

export class AgendaMedico {
    fechaHoraInicio: Date;
    fechaHoraFin: Date;
    noDocumento: string;
}

export class AgendaView extends AgendaMedico {

    codAgenda:number;
    estado:string;
    odontologo:Odontologo;

}