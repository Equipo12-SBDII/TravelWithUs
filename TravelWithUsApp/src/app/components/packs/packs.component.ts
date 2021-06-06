import {Component, Inject, Input, OnInit} from '@angular/core';
import {animate, state, style, transition, trigger} from "@angular/animations";
import {Paquete} from "../table-packs/packs";
import {DOCUMENT} from "@angular/common";
import {PacksTabService} from "./packs.service";

@Component({
  selector: 'app-packs-tab',
  templateUrl: './packs.component.html',
  styleUrls: ['./packs.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class PacksTabComponent implements OnInit {
  packsList: Paquete[] = [];
  count: number = 0;
  columnsToDisplay = ['codigo', 'duracion', 'precio'];
  expandedElement: any;
  @Input('title') title: any;

  constructor(@Inject(DOCUMENT) private document: any, private packService: PacksTabService) { }
  ngOnInit() {
    this.OnGet();
  }
  OnGet() {
    this.packService.GetPaquete().subscribe(
      (response) => {
        this.packsList = response;
        this.count = this.packsList.length;
        console.log('Helloooooooo.')
        console.log(this.packsList);
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
