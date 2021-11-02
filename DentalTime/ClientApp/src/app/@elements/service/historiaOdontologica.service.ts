import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from './@base/handle-http-error.service';
import { HistoriaOdontologica } from '../models/HistoriaOdontologica';

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

}
