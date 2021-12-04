import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { tap, catchError } from "rxjs/operators";
import { HandleHttpErrorService } from "src/app/@base/handle-http-error.service";
import { SolicitudCita, SolicitudView } from "../models/SolicitudCita";


const httpOptions = {
  headers: new HttpHeaders({ "Content-Type": "application/json" }),
};
@Injectable({
  providedIn: 'root'
})
export class SolicitudCitaService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) {
    this.baseUrl = baseUrl;
  }

  post(solicitudCita:SolicitudCita): Observable<SolicitudView> {
    return this.http.post<SolicitudView>(this.baseUrl + "api/SolicitudCita", solicitudCita)
      .pipe(
        tap(() => this.handleErrorService.log("Se envio a guardar")),
        catchError(
          this.handleErrorService.handleError<SolicitudView>(
            "Registrar agenda",
            null
          )
        )
      );
  }
}
