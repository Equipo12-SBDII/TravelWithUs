import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableExcursionComponent } from './table-excursion.component';

describe('TableExcursionComponent', () => {
  let component: TableExcursionComponent;
  let fixture: ComponentFixture<TableExcursionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TableExcursionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TableExcursionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
