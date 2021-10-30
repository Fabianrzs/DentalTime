import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Paciente } from '../models/Paciente';
import { tap, catchError } from 'rxjs/operators';


const httpOptionsPut = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  responseType: 'text'
};


@Injectable({
  providedIn: 'root'
})
export class PacienteService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<Paciente[]> {
    return this.http.get<Paciente[]>(this.baseUrl + 'api/Paciente')
      .pipe(
        tap(_ => this.handleErrorService.log('Consulta Realizada')),
        catchError(this.handleErrorService.handleError<Paciente[]>('Consulta Paciente', null))
      );
  }

  post(paciente: Paciente): Observable<Paciente> {
    return this.http.post<Paciente>(this.baseUrl + 'api/Paciente', paciente)
      .pipe(
        tap(() => this.handleErrorService.log('Se envio a guardar')),
        catchError(this.handleErrorService.handleError<Paciente>('Registrar Persona', null))
      );
  }

  getId(id: string): Observable<Paciente> {
      return this.http.get<Paciente>(`${this.baseUrl + 'api/Paciente'}/Identificacion${id}`)
      .pipe(
        tap(_ => this.handleErrorService.log('Actualizacion')),
        catchError(this.handleErrorService.handleError<Paciente>('Buscar Paciente', null))
      );
  }

}


