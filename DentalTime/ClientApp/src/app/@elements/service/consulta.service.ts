import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Paciente, PacienteView } from '../models/Paciente';
import { tap, catchError } from 'rxjs/operators';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { ConsultaOdontologica, ConsultaOdontologicaView } from '../models/ConsultaOdontologica';

const httpOptionsPut = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  responseType: 'text'
};

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class ConsultaService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }

  getId(idPaciente:string): Observable<ConsultaOdontologicaView[]> {
    const url = `${this.baseUrl + 'api/ConsultaOdontologica'}/${idPaciente}`;
    return this.http.get<ConsultaOdontologicaView[]>(url, httpOptions).pipe(
      tap((_) => this.handleErrorService.log("Consulta realizada")),
      catchError(
        this.handleErrorService.handleError<ConsultaOdontologicaView[]>(
          "Consulta Servicio",
          null
        )
      )
    );
  }

  get(): Observable<ConsultaOdontologica[]> {
    return this.http.get<ConsultaOdontologica[]>(this.baseUrl + "api/ConsultaOdontologica").pipe(
      tap((_) => this.handleErrorService.log("Consulta realizada")),
      catchError(
        this.handleErrorService.handleError<ConsultaOdontologica[]>(
          "Consulta Servicio",
          null
        )
      )
    );
  }

  post(servicio: ConsultaOdontologica): Observable<ConsultaOdontologica> {
  
    return this.http.post<ConsultaOdontologica>(this.baseUrl + "api/ConsultaOdontologica", servicio)
      .pipe(
        tap((_) => this.handleErrorService.log("Se envio a guardar")),
        catchError(
          this.handleErrorService.handleError<ConsultaOdontologica>(
            "Registrar Servicio",
            null
          )
        )
      );
  }
}