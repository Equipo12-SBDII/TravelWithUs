import { TestBed } from '@angular/core/testing';

import { TouristsTabService } from './tourists.service';

describe('TouristsTabService', () => {
  let service: TouristsTabService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TouristsTabService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
