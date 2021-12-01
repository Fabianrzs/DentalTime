import { HistoriaOdontologica } from "./HistoriaOdontologica";
import { Procedimientos } from "./Procedimientos";
import { SolicitudCita } from "./SolicitudCita";

export class ConsultaOdontologicaViewModel {
  idConsultaOdontologica: number;
  motivo: string;
  medicacion: string;
  diagnostico: string;
  valoracion: string;
  recetaMedica: string;
  idSolicitudCita: number;
  solicitudCita: SolicitudCita;
  historiaOdontologica: HistoriaOdontologica;
  procedimientos: Procedimientos;
}
