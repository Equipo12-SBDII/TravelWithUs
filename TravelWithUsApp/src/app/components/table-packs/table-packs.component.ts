import {Component, Inject, Input} from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import {Element} from "@angular/compiler";
import {DOCUMENT} from "@angular/common";
import {ExcursionService} from "../table-excursion/excursion.service";
import {PacksService} from "./packs.service";
import {Paquete} from "./packs";

/**
 * @title Table with expandable rows
 */
@Component({
  selector: 'app-table-packs',
  styleUrls: ['./table-packs.component.scss'],
  templateUrl: './table-packs.component.html',
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class TablePacksComponent {
  packsList: Paquete[] = []
  columnsToDisplay = ['precio', 'duracion'];
  expandedElement: any;
  @Input('title')title: any;

  constructor(@Inject(DOCUMENT) private document: any, private packService: PacksService) { }
  ngOnInit() {
    this.OnGet();
  }
  OnGet() {
    this.packService.GetPaquete().subscribe(
      (response) => {
        this.packsList = response;
        console.log('Helloooooooo.')
        console.log(this.packsList);
      },
      (err) => console.log(err),
    );
  }
  reserve(expandedElement: any) {
    if(expandedElement) {
      console.log(expandedElement)
    }
  }
}
