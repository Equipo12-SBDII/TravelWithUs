import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableOffersHotelComponent } from './table-offers-hotel.component';

describe('TableOffersHotelComponent', () => {
  let component: TableOffersHotelComponent;
  let fixture: ComponentFixture<TableOffersHotelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TableOffersHotelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TableOffersHotelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
