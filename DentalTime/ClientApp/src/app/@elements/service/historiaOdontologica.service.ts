import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { HistoriaOdontologica } from '../models/HistoriaOdontologica';

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
export class HistoriaOdontologicaService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }

  post(historiaOdontologica: HistoriaOdontologica): Observable<HistoriaOdontologica> {
    return this.http.post<HistoriaOdontologica>(this.baseUrl + 'api/HistoriaOdontologica', historiaOdontologica)
      .pipe(
        tap(_ => this.handleErrorService.log('Se envio a guardar')),
        catchError(this.handleErrorService.handleError<HistoriaOdontologica>('Registrar Historia Odontologica', null))
      );
  }

  getId(id: string): Observable<HistoriaOdontologica> {
    const url = `${this.baseUrl + 'api/HistoriaOdontologica'}/${id}`;
    return this.http.get<HistoriaOdontologica>(url, httpOptions)
      .pipe(
        tap(_ => this.handleErrorService.log('datos Buscados')),
        catchError(this.handleErrorService.handleError<HistoriaOdontologica>('Buscar Paciente', null))
      );
  }

}
