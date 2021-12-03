import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Paciente } from "../models/Paciente";
import { tap, catchError } from "rxjs/operators";
import { HandleHttpErrorService } from "src/app/@base/handle-http-error.service";
import { AgendaMedico, AgendaView, FiltroInputModel } from "../models/agendaMedico";

const httpOptionsPut = {
  headers: new HttpHeaders({ "Content-Type": "application/json" }),
  responseType: "text",
};

const httpOptions = {
  headers: new HttpHeaders({ "Content-Type": "application/json" }),
};
@Injectable({
  providedIn: "root",
})
export class AgendaMedicoService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) {
    this.baseUrl = baseUrl;
  }
  
  get(id: string): Observable<AgendaView[]> {
    const url = `${this.baseUrl + 'api/Agenda'}/${id}`;
    return this.http.get<AgendaView[]>(url, httpOptions)
      .pipe(
        tap(_ => this.handleErrorService.log('datos Buscados')),
        catchError(this.handleErrorService.handleError<AgendaView[]>('Buscar Paciente', null))
      );
  }

  post(agendaMedico: AgendaMedico): Observable<AgendaView> {
    return this.http
      .post<AgendaView>(this.baseUrl + "api/Agenda", agendaMedico)
      .pipe(
        tap(() => this.handleErrorService.log("Se envio a guardar")),
        catchError(
          this.handleErrorService.handleError<AgendaView>(
            "Registrar agenda",
            null
          )
        )
      );
  }

  postFiltro(filtroInputMolde: FiltroInputModel): Observable<AgendaView[]> {
    return this.http
      .post<AgendaView[]>(this.baseUrl + "api/Agenda/Filtro", filtroInputMolde)
      .pipe(
        tap(() => this.handleErrorService.log("Se envio a guardar")),
        catchError(
          this.handleErrorService.handleError<AgendaView[]>(
            "Registrar agenda",
            null
          )
        )
      );
  }
}
