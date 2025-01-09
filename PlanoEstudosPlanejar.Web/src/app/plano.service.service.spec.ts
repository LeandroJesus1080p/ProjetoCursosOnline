import { TestBed } from '@angular/core/testing';

import { PlanoServiceService } from './plano.service.service';

describe('PlanoServiceService', () => {
  let service: PlanoServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PlanoServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
