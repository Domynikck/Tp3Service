/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { GaleriesService } from './Galeries.service';

describe('Service: Galeries', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GaleriesService]
    });
  });

  it('should ...', inject([GaleriesService], (service: GaleriesService) => {
    expect(service).toBeTruthy();
  }));
});
