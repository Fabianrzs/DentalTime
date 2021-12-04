/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { SolicitudCitaService } from './solicitudCita.service';

describe('Service: SolicitudCita', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SolicitudCitaService]
    });
  });

  it('should ...', inject([SolicitudCitaService], (service: SolicitudCitaService) => {
    expect(service).toBeTruthy();
  }));
});
