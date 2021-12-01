import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { ConsultaOdontologica } from '../models/ConsultaOdontologica';

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
export class ConsultaOdontologicaService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }

  post(consultaOdontologica: ConsultaOdontologica): Observable<ConsultaOdontologica> {
    return this.http.post<ConsultaOdontologica>(this.baseUrl + 'api/ConsultaOdontologica', consultaOdontologica)
      .pipe(
        tap(_ => this.handleErrorService.log('Se envio a guardar')),
        catchError(this.handleErrorService.handleError<ConsultaOdontologica>('Registrar Historia Odontologica', null))
      );
  }
  
  getId(id: string): Observable<ConsultaOdontologica[]> {
    const url = `${this.baseUrl + 'api/ConsultaOdontologica'}/${id}`;
    return this.http.get<ConsultaOdontologica[]>(url, httpOptions)
      .pipe(
        tap(_ => this.handleErrorService.log('datos Buscados')),
        catchError(this.handleErrorService.handleError<ConsultaOdontologica[]>('Buscar Paciente', null))
      );
  }
  
}
