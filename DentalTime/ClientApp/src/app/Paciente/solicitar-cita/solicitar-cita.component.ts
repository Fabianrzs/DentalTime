import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Odontologo } from 'src/app/@elements/models/Odontologo';
import { OdontologoService } from 'src/app/@elements/service/Odontologo.service';

@Component({
  selector: 'app-solicitar-cita',
  templateUrl: './solicitar-cita.component.html',
  styleUrls: ['./solicitar-cita.component.css']
})
export class SolicitarCitaComponent implements OnInit {

  odontologos: Odontologo[];

  constructor(
    private service:OdontologoService
  ) { }

  ngOnInit() {
    this.service.get().subscribe(result => {
      this.odontologos = result;
    });
  }

  control = new FormControl('', Validators.required);
  selectFormControl = new FormControl('', Validators.required);
  animals: Animal[] = [
    {name: 'Dog', sound: 'Woof!'},
    {name: 'Cat', sound: 'Meow!'},
    {name: 'Cow', sound: 'Moo!'},
    {name: 'Fox', sound: 'Wa-pa-pa-pa-pa-pa-pow!'},
  ];

}
interface Animal {
  name: string;
  sound: string;
}