/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ServiceUtilisateurService } from './Utilisateur.service';

describe('Service: ServiceUtilisateur', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ServiceUtilisateurService]
    });
  });

  it('should ...', inject([ServiceUtilisateurService], (service: ServiceUtilisateurService) => {
    expect(service).toBeTruthy();
  }));
});
