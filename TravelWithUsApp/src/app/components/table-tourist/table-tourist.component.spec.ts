import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableTouristComponent } from './table-tourist.component';

describe('TableTouristComponent', () => {
  let component: TableTouristComponent;
  let fixture: ComponentFixture<TableTouristComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TableTouristComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TableTouristComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
