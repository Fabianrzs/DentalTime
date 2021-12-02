import { Antecendentes } from "./Antecendentes";

export class ConsultaOdontologica {
    motivo:String;
    medicacion: string;
    diagnostico : string;
    valoracion: string;
    recetaMedica: string;
    antecedente:Antecendentes[]
    noDocumento:String;
    idSolicitudCita: Number;
    IdServicio: Number;
}
