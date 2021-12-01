import { Paciente } from "./Paciente";

export class SolicitudCita {
    idSolicitudCita: number;
    fecha: Date;
    estado: string;
    noDocumentoPaciente: string;
    paciente: Paciente;
}
