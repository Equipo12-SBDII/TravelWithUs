import {Component, Inject, Input} from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import {Element} from "@angular/compiler";
import {Agencia} from "./agencies";
import {DOCUMENT} from "@angular/common";
import {ExcursionService} from "../table-excursion/excursion.service";
import {AgenciesService} from "./agencies.service";

/**
 * @title Table with expandable rows
 */
@Component({
  selector: 'app-table-agencies',
  styleUrls: ['./table-agencies.component.scss'],
  templateUrl: './table-agencies.component.html',
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class TableAgenciesComponent {
  agenciesList: Agencia[] = []
  columnsToDisplay = ['nombre', 'direccion', 'email', 'fax'];
  expandedElement: any;
  @Input('title')title: any;

  constructor(@Inject(DOCUMENT) private document: any, private agencyService: AgenciesService) { }
  ngOnInit() {
    this.OnGet();
  }
  OnGet() {
    this.agencyService.GetAgencia().subscribe(
      (response) => {
        this.agenciesList = response;
        console.log('Helloooooooo.')
        console.log(this.agenciesList);
      },
      (err) => console.log(err),
    );
  }

  reserve(expandedElement: any) {
    if(expandedElement) {
      console.log(expandedElement);
    }
  }
}

