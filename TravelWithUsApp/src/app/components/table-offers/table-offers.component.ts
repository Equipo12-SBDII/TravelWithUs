import {Component, Input} from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import {Element} from "@angular/compiler";

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
  dataSource = ELEMENT_DATA;
  columnsToDisplay = ['Oferta', 'Precio', 'Hotel', 'position'];
  expandedElement: any;
  @Input('title')title: any;

  reserve(expandedElement: any) {
    if(expandedElement) {
      console.log(expandedElement.Oferta)
    }
  }
}

export interface Elements {
  Oferta: string;
  position: number;
  Precio: number;
  Hotel: string;
  description: string;
}

const ELEMENT_DATA: Elements[] = [
  {
    position: 1,
    Oferta: 'Hydrogen',
    Precio: 1.0079,
    Hotel: 'H',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    position: 2,
    Oferta: 'Helium',
    Precio: 4.0026,
    Hotel: 'He',
    description: `Helium is a chemical element with symbol He and atomic number 2. It is a
        colorless, odorless, tasteless, non-toxic, inert, monatomic gas, the first in the noble gas
        group in the periodic table. Its boiling point is the lowest among all the elements.`
  }, {
    position: 3,
    Oferta: 'Lithium',
    Precio: 6.941,
    Hotel: 'Li',
    description: `Lithium is a chemical element with symbol Li and atomic number 3. It is a soft,
        silvery-white alkali metal. Under standard conditions, it is the lightest metal and the
        lightest solid element.`
  }, {
    position: 4,
    Oferta: 'Beryllium',
    Precio: 9.0122,
    Hotel: 'Be',
    description: `Beryllium is a chemical element with symbol Be and atomic number 4. It is a
        relatively rare element in the universe, usually occurring as a product of the spallation of
        larger atomic nuclei that have collided with cosmic rays.`
  }, {
    position: 5,
    Oferta: 'Boron',
    Precio: 10.811,
    Hotel: 'B',
    description: `Boron is a chemical element with symbol B and atomic number 5. Produced entirely
        by cosmic ray spallation and supernovae and not by stellar nucleosynthesis, it is a
        low-abundance element in the Solar system and in the Earth's crust.`
  }, {
    position: 6,
    Oferta: 'Carbon',
    Precio: 12.0107,
    Hotel: 'C',
    description: "Carbon is a chemical element with symbol C and atomic number 6. It is nonmetallic " +
      "and tetravalent—making four electrons available to form covalent chemical bonds. It belongs " +
      "to group 14 of the periodic table."
  },
];
