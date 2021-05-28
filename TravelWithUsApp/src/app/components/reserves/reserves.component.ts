import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-reserves',
  templateUrl: './reserves.component.html',
  styleUrls: ['./reserves.component.scss']
})
export class ReservesComponent implements OnInit {
  typesOfShoes: string[] = ['Boots', 'Clogs', 'Loafers', 'Moccasins', 'Sneakers'];
  constructor() { }

  ngOnInit(): void {
  }

  deleteReserve(reserve: string) {
    let temp: string[] = [];
    for(let i =0;i<this.typesOfShoes.length;i++){
      if(this.typesOfShoes[i]!=reserve){
        temp.push(this.typesOfShoes[i]);
      }
    }
    this.typesOfShoes = temp;
  }

  openDialog() {

  }
}
