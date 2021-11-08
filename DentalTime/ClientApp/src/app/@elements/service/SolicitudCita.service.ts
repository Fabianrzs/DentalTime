import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { SolicitudCita } from '../models/SolicitudCita';

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
export class SolicitudCitaService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<SolicitudCita[]> {
    return this.http.get<SolicitudCita[]>(this.baseUrl + 'api/SolicitudCita')
      .pipe(
        tap(_ => this.handleErrorService.log('Consulta realizada')),
        catchError(this.handleErrorService.handleError<SolicitudCita[]>('Consulta Citas', null))
      );
  }

  post(servicio: SolicitudCita): Observable<SolicitudCita>{
    return this.http.post<SolicitudCita>(this.baseUrl+ 'api/SolicitudCita', servicio)
    .pipe(
      tap(_ => this.handleErrorService.log('Se envio a guardar')),
      catchError(this.handleErrorService.handleError<SolicitudCita>('Registrar Cita', null))
    );
  }
  getId(id: number): Observable<SolicitudCita> {
    const url = `${this.baseUrl + 'api/SolicitudCita'}/${id}`;
    return this.http.get<SolicitudCita>(url, httpOptions)
      .pipe(
        tap(_ => this.handleErrorService.log('datos Buscados')),
        catchError(this.handleErrorService.handleError<SolicitudCita>('Buscar Cita', null))
      );
  }

  put(cita: SolicitudCita): Observable<any> {
    const url = `${this.baseUrl}api/SolicitudCita/${cita.idSolicitudCita}`;
    return this.http.put(url, cita, httpOptions)
    .pipe(
      tap(_ => this.handleErrorService.log('Datos Modificados')),
      catchError(this.handleErrorService.handleError<any>('Editar Cita'))
    );
  }

  // put(paciente: Paciente): Observable<any> {
  //   const url = `${this.baseUrl}api/Paciente/${paciente.noDocumento}`;
  //   return this.http.put(url, paciente, httpOptions)
  //   .pipe(
  //     tap(_ => this.handleErrorService.log('Datos Modificados')),
  //     catchError(this.handleErrorService.handleError<any>('Editar Persona'))
  //   );
  // }

}
