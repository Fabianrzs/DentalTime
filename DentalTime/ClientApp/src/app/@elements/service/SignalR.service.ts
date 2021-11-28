import { HttpClient } from '@angular/common/http';
import { EventEmitter, Inject, Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

private hubConnection: signalR.HubConnection;
signalReceived = new EventEmitter<any>();
baseUrl: string;
constructor(
  @Inject("BASE_URL") baseUrl: string,
  private handleErrorService: HandleHttpErrorService) {
  this.baseUrl = baseUrl;
  this.buildConnection();
  this.startConnection();
 }
 private buildConnection = () => {
  this.hubConnection = new signalR.HubConnectionBuilder()
  .withUrl(this.baseUrl+"signalHub") 
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
}
