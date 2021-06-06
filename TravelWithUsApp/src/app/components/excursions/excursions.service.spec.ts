import { TestBed } from '@angular/core/testing';

import { ExcursionsTabService } from './excursions.service';

describe('ExcursionsService', () => {
  let service: ExcursionsTabService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExcursionsTabService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
