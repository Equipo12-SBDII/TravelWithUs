import {Component, Inject, Input, OnInit} from '@angular/core';
import {animate, state, style, transition, trigger} from "@angular/animations";
import {Excursion} from "./excursions";
import {DOCUMENT} from "@angular/common";
import {ExcursionsTabService} from "./excursions.service";

@Component({
  selector: 'app-excursions-tab',
  templateUrl: './excursions.component.html',
  styleUrls: ['./excursions.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class ExcursionsTabComponent implements OnInit {
  excursionList: Excursion[] = []
  columnsToDisplay = ['lugarSalida', 'lugarLlegada', 'fechaSalida', 'fechaLlegada', 'precio'];
  expandedElement: any;
  @Input('title') title: any;


  constructor(@Inject(DOCUMENT) private document: any, private excursionService: ExcursionsTabService) {
  }

  ngOnInit() {
    this.OnGet();
  }

  OnGet() {
    this.excursionService.GetExcursion().subscribe(
      (response) => {
        this.excursionList = response;
        console.log('Helloooooooo.')
        console.log(this.excursionList);
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
