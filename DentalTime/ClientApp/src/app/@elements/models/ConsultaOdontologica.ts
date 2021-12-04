import { Antecendentes } from "./Antecendentes";
import { Paciente, PacienteView } from "./Paciente";
import { Servicio, ServicioView } from "./Servicio";
import { SolicitudCita, SolicitudView } from "./SolicitudCita";

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
    servicio:ServicioView;
    solicitudCita:SolicitudView;
    paciente: PacienteView;

}
