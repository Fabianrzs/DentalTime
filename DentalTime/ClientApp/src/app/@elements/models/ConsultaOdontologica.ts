import { Antecendentes } from "./Antecendentes";
import { Paciente } from "./Paciente";
import { Servicio } from "./Servicio";
import { SolicitudCita } from "./SolicitudCita";

export class ConsultaOdontologica {

    motivo:String;
    medicacion: string;
    diagnostico : string;
    valoracion: string;
    recetaMedica: string;
    antecedente: Antecendentes;
    noDocumento:String;
    idSolicitudCita: Number;
    IdServicio: Number;

}

export class ConsultaOdontologicaView extends ConsultaOdontologica{

    codConsultaClinica:number;
    servicio:Servicio;
    solicitudCita:SolicitudCita;
    paciente: Paciente;

}
