import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TablePacksComponent } from './table-packs.component';

describe('TablePacksComponent', () => {
  let component: TablePacksComponent;
  let fixture: ComponentFixture<TablePacksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TablePacksComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TablePacksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
