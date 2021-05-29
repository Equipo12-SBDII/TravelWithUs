import {Component, Inject, OnInit} from '@angular/core';
import {DOCUMENT} from "@angular/common";

@Component({
  selector: 'app-reserves',
  templateUrl: './reserves.component.html',
  styleUrls: ['./reserves.component.scss']
})
export class ReservesComponent implements OnInit {
  Reserves: string[] = ['Melia', 'Varadero', 'Cohiba', 'Nacional', 'Panorama'];

  constructor(@Inject(DOCUMENT) private document: any) {
  }

  ngOnInit(): void {
  }

  deleteReserve(reserve: string) {
    if (this.Reserves.length >= 1) {
      if (this.Reserves[0] == 'No hay reservas') {
        return
      }
      else{
        let temp: string[] = [];
        for (let i = 0; i < this.Reserves.length; i++) {
          if (this.Reserves[i] != reserve) {
            temp.push(this.Reserves[i]);
          }
        }
        this.Reserves = temp;
        if(this.Reserves.length == 0){
          this.Reserves.push('No hay reservas');
        }
      }
    }
}
  createReserve() {
    this.document.location.href = 'offers';
    /*if(this.Reserves[0] == 'No hay reservas'){
      this.Reserves.pop();
    }
      this.Reserves.push('Cohiba');*/
  }
}
