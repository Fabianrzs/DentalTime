import { ConsultaOdontologica } from "./ConsultaOdontologica";

export class Paciente {
  tipoDocumento: string;
  noDocumento: string;
  nombres: string;
  apellidos: string;
  sexo: string;
  tipoSanguineo: string;
  fechaNacimiento: Date;
  lugarNacimiento: string;
  correoElectronico: string;
  numeroTelefonico: string;
  
}

export class PacienteView extends Paciente   {
  
  consultasOdontologicas: ConsultaOdontologica[];

}