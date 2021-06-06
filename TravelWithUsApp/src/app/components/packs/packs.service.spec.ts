import { TestBed } from '@angular/core/testing';

import { PacksTabService } from './packs.service';

describe('PacksService', () => {
  let service: PacksTabService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PacksTabService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
