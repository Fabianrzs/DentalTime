import { Pipe, PipeTransform } from '@angular/core';
import { Paciente } from '../models/Paciente';

@Pipe({
  name: 'filtroPaciente'
})
export class FiltroPacientePipe implements PipeTransform {

  transform(paciente: Paciente[], searchText: string): any {
    if(searchText == null) return paciente;
    return paciente.filter(p =>
      p.nombres.toLowerCase()
     .indexOf(searchText.toLowerCase()) !== -1);
     
  }

}
