import {Component, Inject, Input, OnInit} from '@angular/core';
import {animate, state, style, transition, trigger} from "@angular/animations";
import {Turista} from "./tourist";
import {DOCUMENT} from "@angular/common";
import {TouristsTabService} from "./tourists.service";

@Component({
  selector: 'app-tourists-tab',
  templateUrl: './tourists.component.html',
  styleUrls: ['./tourists.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class TouristsTabComponent implements OnInit {
  touristList: Turista[] = []
  columnsToDisplay = ['nombre', 'nacionalidad', 'email'];
  expandedElement: any;
  @Input('title') title: any;

  constructor(@Inject(DOCUMENT) private document: any, private touristService: TouristsTabService) { }
  ngOnInit() {
    this.OnGet();
  }
  OnGet() {
    this.touristService.GetTurista().subscribe(
      (response) => {
        this.touristList = response;
        console.log('Helloooooooo.')
        console.log(this.touristList);
      },
      (err) => console.log(err),
    );
  }
  reserve(expandedElement: any) {
    if (expandedElement) {
      console.log(expandedElement)
    }
  }
}
