import { Component, OnInit, Inject } from '@angular/core';
import { DOCUMENT } from "@angular/common";

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.scss']
})
export class CarouselComponent implements OnInit {

  constructor(@Inject(DOCUMENT) private document: any) { }

  ngOnInit(): void {
    ('.carousel');
  }

}
