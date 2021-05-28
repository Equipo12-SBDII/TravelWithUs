import {Component, Inject, Injectable, Output} from "@angular/core";
import {NONE_TYPE} from "@angular/compiler";
import {DOCUMENT} from "@angular/common";

@Component({
  selector: "app-login",
  templateUrl: './login.component.html',
  styleUrls: ["./login.component.scss"]
})
export class LoginComponent {
  password: any;
  name: any;

  constructor(@Inject(DOCUMENT) private document: any) {
    this.name = null;
    this.password = null;
  }
  login() {
    console.log(this.name);
    console.log(this.password);
    this.document.location.href = '/home';
  }
  goToRegister(){
    this.document.location.href = '/register';
  }
}
