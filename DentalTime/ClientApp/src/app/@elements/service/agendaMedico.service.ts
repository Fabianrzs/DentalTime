import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Paciente } from "../models/Paciente";
import { tap, catchError } from "rxjs/operators";
import { HandleHttpErrorService } from "src/app/@base/handle-http-error.service";
import { AgendaMedico } from "../models/agendaMedico";

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
  
  get(): Observable<AgendaMedico[]> {
    return this.http.get<AgendaMedico[]>(this.baseUrl + "api/Agenda").pipe(
      tap((_) => this.handleErrorService.log("Consulta Realizada")),
      catchError(
        this.handleErrorService.handleError<AgendaMedico[]>(
          "Consulta Paciente",
          null
        )
      )
    );
  }

  post(agendaMedico: AgendaMedico): Observable<AgendaMedico> {
    return this.http
      .post<AgendaMedico>(this.baseUrl + "api/Agenda", agendaMedico)
      .pipe(
        tap(() => this.handleErrorService.log("Se envio a guardar")),
        catchError(
          this.handleErrorService.handleError<AgendaMedico>(
            "Registrar agenda",
            null
          )
        )
      );
  }
}
