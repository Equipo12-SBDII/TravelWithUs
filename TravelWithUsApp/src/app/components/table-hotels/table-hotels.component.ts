import { Component, Inject, Input, OnInit } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { Element } from "@angular/compiler";
import { DOCUMENT } from "@angular/common";
import { HotelService } from './hotel.service';
import { Hotel } from './hotel.model';

/**
 * @title Table with expandable rows
 */
@Component({
  selector: 'app-table-hotels',
  styleUrls: ['./table-hotels.component.scss'],
  templateUrl: './table-hotels.component.html',
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class TableHotelsComponent implements OnInit {
  hotelList: Hotel[] = [];
  columnsToDisplay = ['hotelID', 'nombre', 'direccion', 'categoria'];
  expandedElement: any;
  @Input('title') title: any;

  constructor(@Inject(DOCUMENT) private document: any, private hotelService: HotelService) { }

  ngOnInit() {
    this.OnGet();
  }

  reserve(expandedElement: any) {
    if (expandedElement) {
      this.document.location.href = 'hotelpage';
    }
  }

  pageRedirect(expandedElement: any) {
    if (expandedElement) {
      this.document.location.href = 'hotelpage';
    }
  }

    OnGet() {
      this.hotelService.GetHotel().subscribe(
        (response) => {
          this.hotelList = response;
          console.log('Helloooooooo.')
          console.log(this.hotelList);
        },
        (err) => console.log(err),
      );
    }
}
