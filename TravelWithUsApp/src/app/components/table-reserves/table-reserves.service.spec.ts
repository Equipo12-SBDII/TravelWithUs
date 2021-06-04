import { TestBed } from '@angular/core/testing';

import { TableReservesService } from './table-reserves.service';

describe('TableReservesService', () => {
  let service: TableReservesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TableReservesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
