import { HttpClient, HttpHeaders } from "@angular/common/http";
import { EventEmitter, Inject, Injectable } from "@angular/core";
import * as signalR from "@aspnet/signalr";
import { Observable } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { HandleHttpErrorService } from "src/app/@base/handle-http-error.service";
import { Servicio } from "../models/Servicio";

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
export class ServicioService {
  
  private hubConnection: signalR.HubConnection;
  signalReceived = new EventEmitter<any>();
  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) {
    this.baseUrl = baseUrl;
    this.buildConnection();
    this.startConnection();
  }

  private buildConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(this.baseUrl + "/signalHub")
      .build();
  };

  private startConnection = () => {
    this.hubConnection
      .start()
      .then(() => {
        console.log("Connection Started...");
        this.registerSignalEvents();
      })
      .catch((err) => {
        console.log("Error while starting connection: " + err);
        setTimeout(function () {
          this.startConnection();
        }, 3000);
      });
  };

  private registerSignalEvents() {
    this.hubConnection.on("SignalMessageReceived", (data: any) => {
      this.signalReceived.emit(data);
    });
  }

  get(): Observable<Servicio[]> {
    return this.http.get<Servicio[]>(this.baseUrl + "api/Servicio").pipe(
      tap((_) => this.handleErrorService.log("Consulta realizada")),
      catchError(
        this.handleErrorService.handleError<Servicio[]>(
          "Consulta Servicio",
          null
        )
      )
    );
  }

  post(servicio: Servicio): Observable<Servicio> {
    return this.http
      .post<Servicio>(this.baseUrl + "api/Servicio", servicio)
      .pipe(
        tap((_) => this.handleErrorService.log("Se envio a guardar")),
        catchError(
          this.handleErrorService.handleError<Servicio>(
            "Registrar Servicio",
            null
          )
        )
      );
  }

  getId(id: string): Observable<Servicio> {
    const url = `${this.baseUrl + "api/Servicio"}/${id}`;
    return this.http.get<Servicio>(url, httpOptions).pipe(
      tap((_) => this.handleErrorService.log("datos Buscados")),
      catchError(
        this.handleErrorService.handleError<Servicio>("Buscar Cita", null)
      )
    );
  }
}
