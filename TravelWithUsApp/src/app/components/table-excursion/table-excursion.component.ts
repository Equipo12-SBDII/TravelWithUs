import {Component, Input} from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import {Element} from "@angular/compiler";

/**
 * @title Table with expandable rows
 */
@Component({
  selector: 'app-table-excursion',
  styleUrls: ['./table-excursion.component.scss'],
  templateUrl: './table-excursion.component.html',
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class TableExcursionComponent {
  dataSource = ELEMENT_DATA;
  columnsToDisplay = ['Precio', 'DíaDeSalida', 'DíaDeLLegada', 'HoraDeSalida', 'HoraDeLLegada', 'LugarDeSalida', 'LugarDeLLegada'];
  expandedElement: any;
  @Input('title')title: any;

  reserve(expandedElement: any) {
    if(expandedElement) {
      console.log(expandedElement)
    }
  }
}

export interface Elements {
  Precio: number;
  DíaDeSalida: string;
  DíaDeLLegada: string;
  HoraDeSalida: string;
  HoraDeLLegada: string;
  LugarDeSalida: string;
  LugarDeLLegada: string;
  description: string;
}

const ELEMENT_DATA: Elements[] = [
  {
    Precio: 5,
    DíaDeSalida: '1',
    DíaDeLLegada: '2',
    HoraDeSalida: '0800',
    HoraDeLLegada: '1400',
    LugarDeSalida: 'Hotel',
    LugarDeLLegada: 'Playa',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Precio: 5,
    DíaDeSalida: '1',
    DíaDeLLegada: '2',
    HoraDeSalida: '0800',
    HoraDeLLegada: '1400',
    LugarDeSalida: 'Hotel',
    LugarDeLLegada: 'Playa',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Precio: 5,
    DíaDeSalida: '1',
    DíaDeLLegada: '2',
    HoraDeSalida: '0800',
    HoraDeLLegada: '1400',
    LugarDeSalida: 'Hotel',
    LugarDeLLegada: 'Playa',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Precio: 5,
    DíaDeSalida: '1',
    DíaDeLLegada: '2',
    HoraDeSalida: '0800',
    HoraDeLLegada: '1400',
    LugarDeSalida: 'Hotel',
    LugarDeLLegada: 'Playa',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Precio: 5,
    DíaDeSalida: '1',
    DíaDeLLegada: '2',
    HoraDeSalida: '0800',
    HoraDeLLegada: '1400',
    LugarDeSalida: 'Hotel',
    LugarDeLLegada: 'Playa',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Precio: 5,
    DíaDeSalida: '1',
    DíaDeLLegada: '2',
    HoraDeSalida: '0800',
    HoraDeLLegada: '1400',
    LugarDeSalida: 'Hotel',
    LugarDeLLegada: 'Playa',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  },
];
