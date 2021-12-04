import { Agenda } from "@syncfusion/ej2-schedule";
import { Paciente } from "./Paciente";

export class SolicitudCita {
    noDocumento: string;
    codAgenda:number;
}

export class SolicitudView extends SolicitudCita{
    idSolicitudCita:number;
    estado:string;
    fecha:Date;
    paciente:Paciente;
    agenda:Agenda;
}