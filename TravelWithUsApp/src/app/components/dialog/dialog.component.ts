import {Component, Input} from '@angular/core';
import {MatDialog} from '@angular/material/dialog';

/**
 * @title Dialog elements
 */
@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',

})
export class DialogComponent {
  @Input('reserve') reserve: string = '';
  constructor(public dialog: MatDialog) {}

  openDialog() {
    this.dialog.open(DialogElementsExampleDialog);
  }
}

@Component({
  selector: 'dialog-example',
  templateUrl: 'dialog-example.html',
})
export class DialogElementsExampleDialog {}
