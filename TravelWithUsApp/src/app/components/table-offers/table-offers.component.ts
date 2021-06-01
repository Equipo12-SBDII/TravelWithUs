import {Component, Inject, Input} from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import {Element} from "@angular/compiler";
import {Oferta} from "./offers";
import {TableOffersService} from "./table-offers.service";
import {DOCUMENT} from "@angular/common";

/**
 * @title Table with expandable rows
 */
@Component({
  selector: 'app-table-offers',
  styleUrls: ['./table-offers.component.scss'],
  templateUrl: './table-offers.component.html',
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class TableOffersComponent {
  offersList: Oferta[] = [];
  //dataSource = ELEMENT_DATA;
  columnsToDisplay = ['nombre', 'hotel', 'precio'];
  expandedElement: any;
  @Input('title')title: any;

  ngOnInit() {
    this.OnGet();
  }
  constructor(@Inject(DOCUMENT) private document: any, private offersService: TableOffersService) { }
  OnGet() {
    this.offersService.GetOferta().subscribe(
      (response) => {
        this.offersList = response;
        console.log('Helloooooooo.')
        console.log(this.offersList);
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

/* export interface Elements {
  Nombre: string;
  Hotel: string;
  Precio: number;
  description: string;
}

const ELEMENT_DATA: Elements[] = [
  {
    Nombre: 'algo',
    Hotel: 'Melia',
    Precio: 1.0079,
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Nombre: 'algo',
    Hotel: 'Melia',
    Precio: 1.0079,
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Nombre: 'algo',
    Hotel: 'Melia',
    Precio: 1.0079,
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  },{
    Nombre: 'algo',
    Hotel: 'Melia',
    Precio: 1.0079,
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Nombre: 'algo',
    Hotel: 'Melia',
    Precio: 1.0079,
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    Nombre: 'algo',
    Hotel: 'Melia',
    Precio: 1.0079,
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  },
];
 */
