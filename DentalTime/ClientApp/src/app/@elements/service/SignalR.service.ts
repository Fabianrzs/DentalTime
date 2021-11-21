import { EventEmitter, Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

private hubConnection: signalR.HubConnection;
signalReceived = new EventEmitter<any>();

constructor() {
  this.buildConnection();
  this.startConnection();
 }

 private buildConnection = () => {
  this.hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5001/signalHub") //use your api adress here and make sure you use right hub name.
    .build();
};
private startConnection = () => {
  this.hubConnection
    .start()
    .then(() => {
      console.log("Connection Started...");
      this.registerSignalEvents();
    })
    .catch(err => {
      console.log("Error while starting connection: " + err);

      //if you get error try to start connection again after 3 seconds.
      setTimeout(function() {
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
