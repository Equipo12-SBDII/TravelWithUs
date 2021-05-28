import {Component, Inject, Input, OnInit, ViewChild} from '@angular/core';
import {DOCUMENT} from "@angular/common";

@Component({
  selector: 'app-expansion-panel',
  templateUrl: './expansion-panel.component.html',
  styleUrls: ['./expansion-panel.component.scss']
})
export class ExpansionPanelComponent implements OnInit {
  panelOpenState = false;
  @Input('name') name: string = '';
  @Input('description') description: string = '';
  @Input('url') url: string = '';
  constructor(@Inject(DOCUMENT) private document: any) {
  }
  ngOnInit(): void {
  }

  urlRedirect() {
    this.document.location.href = this.url;
  }
  pageRedirect(){
    this.document.location.href = 'hotelpage';
  }
}
