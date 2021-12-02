export class AgendaMedico {
    fechaInicio: Date;
    fechaFinal: Date;
    noDocumento: string;
}

export class AgendaView extends AgendaMedico {

    codAgenda:number;
    estado:string;
    odontologo:Odontologo;

}