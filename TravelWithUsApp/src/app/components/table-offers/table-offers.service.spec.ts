import { TestBed } from '@angular/core/testing';

import { TableOffersService } from './table-offers.service';

describe('TableOffersService', () => {
  let service: TableOffersService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TableOffersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
