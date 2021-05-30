import {Component, Input} from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import {Element} from "@angular/compiler";

/**
 * @title Table with expandable rows
 */
@Component({
  selector: 'app-table-agencies',
  styleUrls: ['./table-agencies.component.scss'],
  templateUrl: './table-agencies.component.html',
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class TableAgenciesComponent {
  dataSource = ELEMENT_DATA;
  columnsToDisplay = ['Nombre', 'Dirección', 'Email', 'NúmeroDeFax'];
  expandedElement: any;
  @Input('title')title: any;

  reserve(expandedElement: any) {
    if(expandedElement) {
      console.log(expandedElement);
    }
  }
}

export interface Elements {
  Nombre: string;
  Email: string;
  Dirección: string;
  NúmeroDeFax: string;
  description: string;
}

const ELEMENT_DATA: Elements[] = [
  {
    Nombre: 'Hydrogen',
    Email: '1.0079',
    Dirección: 'adada',
    NúmeroDeFax: 'Has',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Nombre: 'Hydrogen',
    Email: '1.0079',
    Dirección: 'adada',
    NúmeroDeFax: 'Has',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Nombre: 'Hydrogen',
    Email: '1.0079',
    Dirección: 'adada',
    NúmeroDeFax: 'Has',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Nombre: 'Hydrogen',
    Email: '1.0079',
    Dirección: 'adada',
    NúmeroDeFax: 'Has',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Nombre: 'Hydrogen',
    Email: '1.0079',
    Dirección: 'adada',
    NúmeroDeFax: 'Has',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Nombre: 'Hydrogen',
    Email: '1.0079',
    Dirección: 'adada',
    NúmeroDeFax: 'Has',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  },
];

