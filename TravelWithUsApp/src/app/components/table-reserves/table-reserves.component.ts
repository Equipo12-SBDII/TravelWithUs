import { Component, Inject, Input } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { Element } from "@angular/compiler";
import { DOCUMENT } from "@angular/common";
import { Reserva } from "./reserveIndividual";
import { ReserveService } from "../reserve/reserve.service";
import { TableReservesService } from "./table-reserves.service";

/**
 * @title Table with expandable rows
 */
@Component({
  selector: 'app-table-reserves',
  styleUrls: ['./table-reserves.component.scss'],
  templateUrl: './table-reserves.component.html',
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class TableReservesComponent {
  reservesList: Reserva[] = [];
  count: number = 0;
  columnsToDisplay = ['agencia', 'turista', 'precio', 'hotel', 'aereolinea', 'acompananates', 'entrada', 'salida'];
  expandedElement: any;
  @Input('title') title: any;

  constructor(@Inject(DOCUMENT) private document: any, private reservesService: TableReservesService) { }
  ngOnInit() {
    this.OnGet();
  }
  OnGet() {
    this.reservesService.GetReservaIndividual().subscribe(
      (response) => {
        this.reservesList = response;
        this.count = this.reservesList.length;
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
