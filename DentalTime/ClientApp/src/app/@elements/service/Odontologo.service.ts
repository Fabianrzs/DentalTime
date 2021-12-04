import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Odontologo } from '../models/Odontologo';
import { tap, catchError } from 'rxjs/operators';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { SolicitudView } from '../models/SolicitudCita';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class OdontologoService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }

  get(): Observable<Odontologo[]> {
    return this.http.get<Odontologo[]>(this.baseUrl + 'api/Odontologo')
      .pipe(
        tap(_ => this.handleErrorService.log('Consulta Realizada')),
        catchError(this.handleErrorService.handleError<Odontologo[]>('Consulta Odontologo', null))
      );
  }

  post(odontologo: Odontologo): Observable<Odontologo> {
    return this.http.post<Odontologo>(this.baseUrl + 'api/Odontologo', odontologo)
      .pipe(
        tap(() => this.handleErrorService.log('Se envio a guardar')),
        catchError(this.handleErrorService.handleError<Odontologo>('Registrar Odontologo', null))
      );
  }

  getId(id: string): Observable<SolicitudView[]> {
    const url = `${this.baseUrl + 'api/SolicitudCita/odontologo'}/${id}`;
    return this.http.get<SolicitudView[]>(url, httpOptions)
      .pipe(
        tap(_ => this.handleErrorService.log('datos Buscados')),
        catchError(this.handleErrorService.handleError<SolicitudView[]>('Buscar Paciente', null))
      );
  }

}
