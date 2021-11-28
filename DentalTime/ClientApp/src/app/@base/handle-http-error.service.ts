import { Injectable } from "@angular/core";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { Observable, of } from "rxjs";
import { AlertModalComponent } from "./alertModal/alertModal.component";

@Injectable({
  providedIn: "root",
})
export class HandleHttpErrorService {
  constructor(private modal: NgbModal,) {}
  public handleError<T>(operation = "operation", result?: T) {
    return (error: any): Observable<T> => {
      if (error.status == "500") {
        this.mostrarError500(error);
      }
      if (error.status == "400") {
        this.mostrarError400(error);
      }
      return of(result as T);
    };
  }

  mostrarError400(error: any) {
    
    console.error(error);
    let contadorValidaciones: number = 0;
    let mensajeValidaciones: string =`Señor(a) usuario(a), se han presentado algunos errores de validación, por favor revíselos y vuelva a realizar la 
          operación.<br>`;
    for (const prop in error.error.errors) {
      contadorValidaciones++;
      mensajeValidaciones += `<strong>${contadorValidaciones}. ${prop}:</strong>`;
      error.error.errors[prop].forEach((element) => {
        mensajeValidaciones += `<br/> - ${element}`;
      });
      mensajeValidaciones += `<br/>`;
    }
    /*Swal.fire({
      icon: 'error',
      title: 'Oops...',
      text: mensajeValidaciones
    })*/
    const messageBox = this.modal.open(AlertModalComponent);
    messageBox.componentInstance.title = "Operacion Fallida" ;
    messageBox.componentInstance.message = mensajeValidaciones;
  }

  mostrarError500(error: any) {
    console.log(error);
  }

  public log(message: string) {
    console.log(message);
    /*Swal.fire({
      icon: 'error',
      title: 'Oops...',
      text: message
    })*/
  }
}
