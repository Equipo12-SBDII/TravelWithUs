import {Component, Inject, Injectable} from "@angular/core";
import {NONE_TYPE} from "@angular/compiler";
import {DOCUMENT} from "@angular/common";

@Component({
  selector: "app-login",
  templateUrl: './login.component.html',
  styleUrls: ["./login.component.scss"]
})
export class LoginComponent {
  email: any;
  password: any;

  constructor(@Inject(DOCUMENT) private document: any) {
    this.email = null;
    this.password = null;
  }
  login() {
    console.log(this.email);
    console.log(this.password);
    this.document.location.href = '/home';
  }
  goToRegister(){
    this.document.location.href = '/register';
  }
}
