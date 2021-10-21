import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Paciente } from '../models/Paciente';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PacienteServiceService {
  

  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<Paciente[]> {
    return this.http.get<Paciente[]>(this.baseUrl + 'api/paciente')
      .pipe(
        tap(_ => this.handleErrorService.log('Cosulta realizada')),
        catchError(this.handleErrorService.handleError<Paciente[]>('Consulta Paciente', null))
      );
  }

  post(paciente: Paciente): Observable<any>{
    return this.http.post<Paciente>(this.baseUrl+ 'api/paciente', paciente)
    .pipe(
      tap(_ => this.handleErrorService.log('Se envio a guardar')),
      catchError(this.handleErrorService.handleError<Paciente>('Registrar Persona', null))
    );
  }

  
}


