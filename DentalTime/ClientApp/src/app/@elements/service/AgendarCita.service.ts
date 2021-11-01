import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { AgendaCita } from '../models/AgendaCita';

@Injectable({
  providedIn: 'root'
})
export class AgendarCitaService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<AgendaCita[]> {
    return this.http.get<AgendaCita[]>(this.baseUrl + 'api/AgendaCita')
      .pipe(
        tap(_ => this.handleErrorService.log('Consulta realizada')),
        catchError(this.handleErrorService.handleError<AgendaCita[]>('Consulta Citas', null))
      );
  }

  post(servicio: AgendaCita): Observable<AgendaCita>{
    return this.http.post<AgendaCita>(this.baseUrl+ 'api/AgendaCita', servicio)
    .pipe(
      tap(_ => this.handleErrorService.log('Se envio a guardar')),
      catchError(this.handleErrorService.handleError<AgendaCita>('Registrar Cita', null))
    );
  }
}
