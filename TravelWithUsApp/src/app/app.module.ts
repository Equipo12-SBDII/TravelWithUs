import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import {routing} from "./app-routing.module";
import {FormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import {Observable} from "rxjs";
import { HomeComponent } from './home/home.component';
import { ReserveComponent } from './components/reserve/reserve.component';
import {MatSelectModule} from "@angular/material/select";
import {MatInputModule} from "@angular/material/input";
import {MatCardModule} from "@angular/material/card";
import {MatButtonModule} from "@angular/material/button";
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatIconModule} from "@angular/material/icon";
import { NavbarComponent } from './components/navbar/navbar.component';
import { MatSidenavModule} from '@angular/material/sidenav';
import {SidebarComponent} from "./components/sidebar/sidebar.component";
import { ExpansionPanelComponent } from './components/expansion-panel/expansion-panel.component';
import {MatExpansionModule} from "@angular/material/expansion";
import {MatDatepickerModule} from "@angular/material/datepicker";
import { HotelpageComponent } from './hotelpage/hotelpage.component';
import { ReservesComponent } from './components/reserves/reserves.component';
import {MatListModule} from "@angular/material/list";
import {MatDialogModule} from "@angular/material/dialog";
import {DialogComponent, DialogElementsExampleDialog} from './components/dialog/dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    ReserveComponent,
    NavbarComponent,
    SidebarComponent,
    ExpansionPanelComponent,
    HotelpageComponent,
    ReservesComponent,
    DialogComponent,
    DialogElementsExampleDialog
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    routing,
    FormsModule,
    MatSelectModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatCardModule,
    MatButtonModule,
    MatToolbarModule,
    MatIconModule,
    MatSidenavModule,
    MatExpansionModule,
    MatDatepickerModule,
    MatListModule,
    MatDialogModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
