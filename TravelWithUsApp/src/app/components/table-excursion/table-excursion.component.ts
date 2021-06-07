import { Component, Inject, Input } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { Element } from "@angular/compiler";
import { Excursion } from "./excursion";
import { DOCUMENT } from "@angular/common";
import { HotelService } from "../table-hotels/hotel.service";
import { ExcursionService } from "./excursion.service";

/**
 * @title Table with expandable rows
 */
@Component({
  selector: 'app-table-excursion',
  styleUrls: ['./table-excursion.component.scss'],
  templateUrl: './table-excursion.component.html',
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class TableExcursionComponent {
  excursionList: Excursion[] = []
  columnsToDisplay = ['lugarExcursion', 'fechaSalidaExcursion', 'duracionExcursion'];
  expandedElement: any;
  @Input('title') title: any;


  constructor(@Inject(DOCUMENT) private document: any, private excursionService: ExcursionService) { }
  ngOnInit() {
    this.OnGet();
  }
  OnGet() {
    this.excursionService.GetExcursion().subscribe(
      (response) => {
        this.excursionList = response;
        console.log('Helloooooooo.')
        console.log(this.excursionList);
      },
      (err) => console.log(err),
    );
  }
  reserve(expandedElement: any) {
    if (expandedElement) {
      console.log(expandedElement)
    }
  }
}
