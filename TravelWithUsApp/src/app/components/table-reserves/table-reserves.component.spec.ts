import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableReservesComponent } from './table-reserves.component';

describe('TableReservesComponent', () => {
  let component: TableReservesComponent;
  let fixture: ComponentFixture<TableReservesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TableReservesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TableReservesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
