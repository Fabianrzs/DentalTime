import { Component, OnInit } from '@angular/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from '@fullcalendar/timegrid';
import interactionPlugin from '@fullcalendar/interaction';
import esLocale from '@fullcalendar/core/Locales/es';

@Component({
  selector: 'app-agendar-cita',
  templateUrl: './agendar-cita.component.html',
  styleUrls: ['./agendar-cita.component.css']
})
export class AgendarCitaComponent implements OnInit {

  public events: any[];
  public options: any;

  constructor() { }

  ngOnInit() {
    this.options={
      plugins: [dayGridPlugin,timeGridPlugin,interactionPlugin],
      defaultDate : new Date(),
      locale: esLocale,
      header: {
        left: 'prev,next',
        center: 'title',
        rigth: 'dayGridMonth,timeGridWeek,timeGridDay'
      },
      
    };

    this.events = [
      { 
        title: 'Evento 1',
        start: new Date(),
        description: 'hola'
      },
      { 
        title: 'Evento 2',
        start: new Date(new Date().getTime() + 8640000),
        description: 'hola'
      },
      { 
        title: 'Evento 3',
        start: new Date(new Date().getTime() + (8640000*2)),
        end: new Date(new Date().getTime() + (8640000*3)),
        description: 'hola'
      },
      { 
        title: 'Evento 4',
        start: new Date(new Date().getTime() + (86400000*2)),
        end: new Date(new Date().getTime() + (86400000*3)),
        description: 'hola'
      }
    ];
  }

}
