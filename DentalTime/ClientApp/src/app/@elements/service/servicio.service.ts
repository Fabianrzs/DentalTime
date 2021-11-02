import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from './@base/handle-http-error.service';
import { Servicio } from '../models/Servicio';

@Injectable({
  providedIn: 'root'
})
export class ServicioService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<Servicio[]> {
    return this.http.get<Servicio[]>(this.baseUrl + 'api/Servicio')
      .pipe(
        tap(_ => this.handleErrorService.log('Consulta realizada')),
        catchError(this.handleErrorService.handleError<Servicio[]>('Consulta Servicio', null))
      );
  }

  post(servicio: Servicio): Observable<Servicio>{
    return this.http.post<Servicio>(this.baseUrl+ 'api/Servicio', servicio)
    .pipe(
      tap(_ => this.handleErrorService.log('Se envio a guardar')),
      catchError(this.handleErrorService.handleError<Servicio>('Registrar Servicio', null))
    );
  }
}
