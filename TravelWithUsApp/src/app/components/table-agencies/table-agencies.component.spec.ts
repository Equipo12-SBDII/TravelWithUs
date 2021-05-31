import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableAgenciesComponent } from './table-agencies.component';

describe('TableAgenciesComponent', () => {
  let component: TableAgenciesComponent;
  let fixture: ComponentFixture<TableAgenciesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TableAgenciesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TableAgenciesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
