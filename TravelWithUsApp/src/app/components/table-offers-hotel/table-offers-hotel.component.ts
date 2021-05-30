import {Component, Input} from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import {Element} from "@angular/compiler";

/**
 * @title Table with expandable rows
 */
@Component({
  selector: 'app-table-offers-hotel',
  styleUrls: ['./table-offers-hotel.component.scss'],
  templateUrl: './table-offers-hotel.component.html',
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class TableOffersHotelComponent {
  dataSource = ELEMENT_DATA;
  columnsToDisplay = ['No', 'Precio'];
  expandedElement: any;
  @Input('title')title: any;

  reserve(expandedElement: any) {
    if(expandedElement) {
      console.log(expandedElement)
    }
  }
}

export interface Elements {
  No: number;
  Precio: number;
  description: string;
}

const ELEMENT_DATA: Elements[] = [
  {
    No: 1,
    Precio: 1.0079,
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    No: 2,
    Precio: 1.0079,
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    No: 3,
    Precio: 1.0079,
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  },{
    No: 4,
    Precio: 1.0079,
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    No: 5,
    Precio: 1.0079,
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    No: 6,
    Precio: 1.0079,
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  },
];
