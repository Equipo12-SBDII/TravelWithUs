import { TestBed } from '@angular/core/testing';

import { HotelsTabService } from './hotels.service';

describe('HotelsTabService', () => {
  let service: HotelsTabService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HotelsTabService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
