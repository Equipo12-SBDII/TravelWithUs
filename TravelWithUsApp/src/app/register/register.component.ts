import {Component, Inject} from "@angular/core";
import {DOCUMENT} from "@angular/common";

@Component({
  selector: "app-register",
  templateUrl: './register.component.html',
  styleUrls: ["./register.component.scss"]
})
export class RegisterComponent {
  name: string = '';
  password: string = '';
  confirmPassword: string = '';
  nationality: string = '';

  constructor(@Inject(DOCUMENT) private document: any) {}

  register() {
    this.document.location.href = '/login';
    console.log(this.name);
    console.log(this.password);
  }
}
