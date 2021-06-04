import {Component, Inject, OnInit} from '@angular/core';
import { Reserve, Turista, Agencia, Oferta } from './reserve';
import {FormControl, FormGroup} from "@angular/forms";
import {DOCUMENT} from "@angular/common";

/**
 * @title Basic select with initial value and no form
 */
@Component({
  selector: 'reserve',
  templateUrl: 'reserve.component.html',
  styleUrls: ['reserve.component.scss']
})
export class ReserveComponent {
  constructor(@Inject(DOCUMENT) private document: any) { }

  agencies: Agencia[] = [ new Agencia(1,'a')];
  offers: Oferta[] = [new Oferta(1,-1,'dd',1)];
  tourist: Turista[] = [new Turista(1,'a')];
  selectedOff: string = '';
  selectedTou: string = '';
  selectedAge: string = '';
  sO: Oferta = new Oferta(-1,-1,'',-1);
  sT: Turista = new Turista(-1,'');
  sA: Agencia = new Agencia(-1,'');
  reservedPrice: number = 0;
  fechas: any;

  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl()
  });
  aerolinea: string = '';
  numAcompa: number = 0;
  selectAge(event: Event) {
    this.selectedAge = (event.target as HTMLSelectElement).value;
    for(let i of this.agencies){
      if(i.agenciaNombre == this.selectedAge){
        this.sA = i;
      }
    }
  }
  selectTou(event: Event) {
    this.selectedTou = (event.target as HTMLSelectElement).value;
    for(let i of this.tourist){
      if(i.turistaNombre == this.selectedTou){
        this.sT = i;
      }
    }
  }
  selectOff(event: Event) {
    this.selectedOff = (event.target as HTMLSelectElement).value;
    for(let i of this.offers){
      if(i.ofertaDescripcion == this.selectedOff){
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
  date(){
    let input = (this.range.value.start.toISOString())
    let output = (this.range.value.end.toISOString())
    let entrada = '';
    let salida = '';
    for(let i of input){
      if(i == 'T')
        break;

      entrada += i;
    }
    for(let i of output){
      if(i == 'T')
        break;

      salida += i;
    }
    this.fechas = [entrada, salida];
    console.log(this.fechas);
  }
  reserve() {
    this.date();

    this.document.location.href = 'myreserves';
  }

}

