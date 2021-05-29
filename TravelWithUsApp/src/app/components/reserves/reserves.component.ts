import {Component, Inject, OnInit} from '@angular/core';
import {DOCUMENT} from "@angular/common";
import {Element} from "@angular/compiler";


@Component({
  selector: 'app-reserves',
  templateUrl: './reserves.component.html',
  styleUrls: ['./reserves.component.scss']
})
export class ReservesComponent implements OnInit {
  Reserves = reservesIn;
  withoutReserves: Elements = {
    Oferta:"No hay reservas",
    position: 0,
    Hotel: "",
    Precio: 0,
    description: ""
  }
  constructor(@Inject(DOCUMENT) private document: any) {
  }

  ngOnInit(): void {
  }

  deleteReserve(reserve: Elements) {
    if (this.Reserves.length >= 1) {
      if (this.Reserves[0].Oferta == 'No hay reservas') {
        return
      }
      else{
        let temp: Elements[] = [];
        for (let i = 0; i < this.Reserves.length; i++) {
          if (this.Reserves[i] != reserve) {
            temp.push(this.Reserves[i]);
          }
        }
        this.Reserves = temp;
        if(this.Reserves.length == 0){
          this.Reserves.push(this.withoutReserves);
        }
      }
    }
}
  createReserve() {
    this.document.location.href = 'offers';
  }
}

export interface Elements {
  Oferta: string;
  position: number;
  Precio: number;
  Hotel: string;
  description: string;
}

const reservesIn: Elements[] = [
  {
    position: 1,
    Oferta: 'Dos por uno express',
    Precio: 1.0079,
    Hotel: 'Melia Varadero',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    position: 2,
    Oferta: 'Tres Días con piscina',
    Precio: 4.0026,
    Hotel: 'Cohiba',
    description: `Helium is a chemical element with symbol He and atomic number 2. It is a
        colorless, odorless, tasteless, non-toxic, inert, monatomic gas, the first in the noble gas
        group in the periodic table. Its boiling point is the lowest among all the elements.`
  }, {
    position: 3,
    Oferta: 'Playa y psicina por una semana',
    Precio: 6.941,
    Hotel: 'Panorama',
    description: `Lithium is a chemical element with symbol Li and atomic number 3. It is a soft,
        silvery-white alkali metal. Under standard conditions, it is the lightest metal and the
        lightest solid element.`
  }, {
    position: 4,
    Oferta: 'Dos noches interminables',
    Precio: 9.0122,
    Hotel: 'Nacional',
    description: `Beryllium is a chemical element with symbol Be and atomic number 4. It is a
        relatively rare element in the universe, usually occurring as a product of the spallation of
        larger atomic nuclei that have collided with cosmic rays.`
  }, {
    position: 5,
    Oferta: 'Discoteca',
    Precio: 10.811,
    Hotel: 'Habana Libre',
    description: `Boron is a chemical element with symbol B and atomic number 5. Produced entirely
        by cosmic ray spallation and supernovae and not by stellar nucleosynthesis, it is a
        low-abundance element in the Solar system and in the Earth's crust.`
  }, {
    position: 6,
    Oferta: '5 días con todo incluído',
    Precio: 12.0107,
    Hotel: 'Brisas del Mar',
    description: "Carbon is a chemical element with symbol C and atomic number 6. It is nonmetallic " +
      "and tetravalent—making four electrons available to form covalent chemical bonds. It belongs " +
      "to group 14 of the periodic table."
  },
];
