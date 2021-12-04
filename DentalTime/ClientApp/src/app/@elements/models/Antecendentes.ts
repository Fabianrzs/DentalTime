import { ConsultaOdontologica } from "./ConsultaOdontologica";

export class Antecendentes {
  idAntecedente:number;
  enfermedades: string;
  farmaceuticos: string;
  quimicos: string;
  complicaciones: string;
  consultaOdontologica:ConsultaOdontologica;
}

export class AntecendentesView {

  idAntecedente:number;
  consultaOdontologica:ConsultaOdontologica;

}