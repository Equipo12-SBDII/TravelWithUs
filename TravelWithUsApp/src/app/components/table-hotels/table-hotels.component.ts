import {Component, Inject, Input} from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import {Element} from "@angular/compiler";
import {DOCUMENT} from "@angular/common";

/**
 * @title Table with expandable rows
 */
@Component({
  selector: 'app-table-hotels',
  styleUrls: ['./table-hotels.component.scss'],
  templateUrl: './table-hotels.component.html',
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class TableHotelsComponent {
  dataSource = ELEMENT_DATA;
  columnsToDisplay = ['Nombre', 'Dirección', 'Categoría', 'FechaDeSalida', 'FechaDeLlegada'];
  expandedElement: any;
  @Input('title')title: any;

  constructor(@Inject(DOCUMENT) private document: any) { }

  reserve(expandedElement: any) {
    if(expandedElement) {
      this.document.location.href = 'hotelpage';
    }
  }

  pageRedirect(expandedElement: any) {
    if(expandedElement) {
      this.document.location.href = 'hotelpage';
    }
  }
}

export interface Elements {
  Nombre: string;
  Dirección: string;
  Categoría: string;
  FechaDeSalida: string;
  FechaDeLlegada: string;
  description: string;
}

const ELEMENT_DATA: Elements[] = [
  {
    Nombre: 'Hydrogen',
    Dirección: 'adada',
    Categoría: '1.0079',
    FechaDeSalida: 'Has',
    FechaDeLlegada: "rara",
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Nombre: 'Hydrogen',
    Dirección: 'adada',
    Categoría: '1.0079',
    FechaDeSalida: 'Has',
    FechaDeLlegada: "rara",
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Nombre: 'Hydrogen',
    Dirección: 'adada',
    Categoría: '1.0079',
    FechaDeSalida: 'Has',
    FechaDeLlegada: 'rara',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Nombre: 'Hydrogen',
    Dirección: 'adada',
    Categoría: '1.0079',
    FechaDeSalida: 'Has',
    FechaDeLlegada: "rara",
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Nombre: 'Hydrogen',
    Dirección: 'adada',
    Categoría: '1.0079',
    FechaDeSalida: 'Has',
    FechaDeLlegada: "rara",
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Nombre: 'Hydrogen',
    Dirección: 'adada',
    Categoría: '1.0079',
    FechaDeSalida: 'Has',
    FechaDeLlegada: "rara",
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  },
];

