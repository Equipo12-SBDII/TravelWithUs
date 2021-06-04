import { Component, OnInit } from '@angular/core';
import { Reserve, Turista, Agencia, Oferta } from './reserve';

/**
 * @title Basic select with initial value and no form
 */
@Component({
  selector: 'reserve',
  templateUrl: 'reserve.component.html',
  styleUrls: ['reserve.component.scss']
})
export class ReserveComponent {
  agencies: Agencia[] = [];
  offers: Oferta[] = [];
  tourist: Turista[] = [];
  selectedOff: string = '';
  selectedTou: string = '';
  selectedAge: string = '';
  reservedPrice: number = 0;

  selectAge(event: Event) {
    this.selectedAge = (event.target as HTMLSelectElement).value;
  }
  selectTou(event: Event) {
    this.selectedTou = (event.target as HTMLSelectElement).value;
  }
  selectOff(event: Event) {
    this.selectedOff = (event.target as HTMLSelectElement).value;
  }
  price() {
    this.reservedPrice = 0;
    for (let off of this.offers) {
      if (off.ofertaDescripcion == this.selectedOff) this.reservedPrice += off.ofertaPrecio;
    }
  }
}

