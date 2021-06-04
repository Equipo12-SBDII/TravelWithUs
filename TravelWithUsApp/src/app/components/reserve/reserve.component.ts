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
  sO: Oferta = new Oferta(-1,'','',-1,'');
  sT: Turista = new Turista('','',-1);
  sA: Agencia = new Agencia(-1,'',-1,-1);
  reservedPrice: number = 0;

  selectAge(event: Event) {
    this.selectedAge = (event.target as HTMLSelectElement).value;
    for(let i of this.agencies){
      if(i.nombre == this.selectedAge){
        this.sA = i;
      }
    }
  }
  selectTou(event: Event) {
    this.selectedTou = (event.target as HTMLSelectElement).value;
    for(let i of this.tourist){
      if(i.nombre == this.selectedTou){
        this.sT = i;
      }
    }
  }
  selectOff(event: Event) {
    this.selectedOff = (event.target as HTMLSelectElement).value;
    for(let i of this.offers){
      if(i.descripcion == this.selectedOff){
        this.sO = i;
      }
    }
  }
  price() {
    this.reservedPrice = 0;
    for (let off of this.offers) {
      if (off.ofertaDescripcion == this.selectedOff) this.reservedPrice += off.ofertaPrecio;
    }
  }

  reserve() {

  }
}

