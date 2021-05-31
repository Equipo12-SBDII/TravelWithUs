import { Component, Inject, OnInit } from '@angular/core';
import { DOCUMENT } from "@angular/common";
import { OfferService } from "./offer.service";
import { Offer } from './offer.model'

@Component({
  selector: 'app-offers',
  templateUrl: './offers.component.html',
  styleUrls: ['./offers.component.scss']
})
export class OffersComponent implements OnInit {
  offerList!: Offer[];
  constructor(@Inject(DOCUMENT) private document: any, private offerService: OfferService) { }

  ngOnInit(): void {
    this.offerService.getData().subscribe(
      (data) => {
        this.offerList = data;
      }, (err) => console.log(err)
    );
  }

}
