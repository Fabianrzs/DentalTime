import { Pipe, PipeTransform } from '@angular/core';
import { Servicio } from '../models/Servicio';

@Pipe({
  name: 'filtro-servicio'
})
export class FiltroServicioPipe implements PipeTransform {

  transform(servicio: Servicio[], searchText: string): any {
    if(searchText == null) return servicio;
    return servicio.filter(p =>
      p.idServico.toLowerCase()
     .indexOf(searchText.toLowerCase()) !== -1);
  }
}
