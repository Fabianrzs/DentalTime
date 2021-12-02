import { ConsultaOdontologica } from "./ConsultaOdontologica";

export class Antecendentes {
  enfermedades: string;
  farmaceuticos: string;
  quimicos: string;
  complicaciones: string;
}

export class AntecendentesView extends Antecendentes {

  idAntecedente:number;
  consultaOdontologica:ConsultaOdontologica;

}