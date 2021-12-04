import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { Producto } from '../models/Producto';


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
export class ProductoService {

baseUrl: string;
constructor(
  private http: HttpClient,
  @Inject('BASE_URL') baseUrl: string,
  private handleErrorService: HandleHttpErrorService) {
  this.baseUrl = baseUrl;
}

get(): Observable<Producto[]> {
  return this.http.get<Producto[]>(this.baseUrl + 'api/Producto')
    .pipe(
      tap(_ => this.handleErrorService.log('Consulta Realizada')),
      catchError(this.handleErrorService.handleError<Producto[]>('Consulta Producto', null))
    );
}

post(paciente: Producto): Observable<Producto> {
  return this.http.post<Producto>(this.baseUrl + 'api/Producto', paciente)
    .pipe(
      tap(() => this.handleErrorService.log('Se envio a guardar')),
      catchError(this.handleErrorService.handleError<Producto>('Registrar Producto', null))
    );
}

}
