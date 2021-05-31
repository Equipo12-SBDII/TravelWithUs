import {Component, Inject, Input} from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import {Element} from "@angular/compiler";
import {DOCUMENT} from "@angular/common";
import {AgenciesService} from "../table-agencies/agencies.service";
import {TuristaService} from "./tourist.service";
import {Turista} from "./tourist";

/**
 * @title Table with expandable rows
 */
@Component({
  selector: 'app-table-tourist',
  styleUrls: ['./table-tourist.component.scss'],
  templateUrl: './table-tourist.component.html',
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class TableTouristComponent {
  touristList: Turista[] = []
  dataSource = ELEMENT_DATA;
  columnsToDisplay = ['nombre', 'nacionalidad'];
  expandedElement: any;
  @Input('title')title: any;

  constructor(@Inject(DOCUMENT) private document: any, private touristService: TuristaService) { }
  ngOnInit() {
    this.OnGet();
  }
  OnGet() {
    this.touristService.GetTurista().subscribe(
      (response) => {
        this.touristList = response;
        console.log('Helloooooooo.')
        console.log(this.touristList);
      },
      (err) => console.log(err),
    );
  }
  reserve(expandedElement: any) {
    if(expandedElement) {
      console.log(expandedElement)
    }
  }
}

export interface Elements {
  Nombre: string;
  Nacionalidad: string;
  description: string;
}

const ELEMENT_DATA: Elements[] = [
  {
    Nombre: 'Hydrogen',
    Nacionalidad: 'H',
    description: ''
  }, {
    Nombre: 'Hydrogen',
    Nacionalidad: 'H',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Nombre: 'Hydrogen',
    Nacionalidad: 'H',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Nombre: 'Hydrogen',
    Nacionalidad: 'H',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Nombre: 'Hydrogen',
    Nacionalidad: 'H',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Nombre: 'Hydrogen',
    Nacionalidad: 'H',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  },
];
