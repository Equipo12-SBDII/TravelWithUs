import {Component, OnInit} from '@angular/core';

interface Agency {
  value: string;
  viewValue: string;
  price: number;
}

interface Hotel {
  value: string;
  viewValue: string;
  price: number;
}

interface Company {
  value: string;
  viewValue: string;
  price: number;
}

/**
 * @title Basic select with initial value and no form
 */
@Component({
  selector: 'reserve',
  templateUrl: 'reserve.component.html',
  styleUrls: ['reserve.component.scss']
})
export class ReserveComponent {
  agencies: Agency[] = [
    {value: 'steak', viewValue: 'Steak', price: 111},
    {value: 'pizza', viewValue: 'Pizza', price: 101},
    {value: 'tacos', viewValue: 'Tacos', price: 122}
  ];
  hotels: Hotel[] = [
    {value: 'ford', viewValue: 'Ford', price: 11},
    {value: 'chevrolet', viewValue: 'Chevrolet', price: 12},
    {value: 'dodge', viewValue: 'Dodge', price: 15}
  ];
  companies: Company[] = [
    {value: 'ford', viewValue: 'Ford', price: 1},
    {value: 'chevrolet', viewValue: 'Chevrolet', price:2},
    {value: 'dodge', viewValue: 'Dodge', price:3}
  ];
  sCom = this.companies[2];
  sHot = this.hotels[0];
  sAge = this.agencies[0];
  selectedCom = this.sCom.value;
  selectedHot = this.sHot.value;
  selectedAge = this.sAge.value;
  reservedPrice: number = this.sCom.price + this.sHot.price + this.sAge.price;

  selectAge(event: Event) {
    this.selectedAge = (event.target as HTMLSelectElement).value;
  }
  selectHot(event: Event) {
    this.selectedHot = (event.target as HTMLSelectElement).value;
  }
  selectCom(event: Event) {
    this.selectedCom = (event.target as HTMLSelectElement).value;
  }
  price(){
    this.reservedPrice = 0;
    for(let comp of this.companies){
      if (comp.value == this.selectedCom) this.reservedPrice+= comp.price;
    }
    for(let hot of this.hotels){
      if (hot.value == this.selectedHot) this.reservedPrice+= hot.price;
    }
    for(let age of this.agencies){
      if (age.value == this.selectedAge) this.reservedPrice+= age.price;
    }
  }
}

