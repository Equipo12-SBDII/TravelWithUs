import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { routing } from "./app-routing.module";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { from, Observable } from "rxjs";
import { HomeComponent } from './home/home.component';
import { ReserveComponent } from './components/reserve/reserve.component';
import { MatSelectModule } from "@angular/material/select";
import { MatInputModule } from "@angular/material/input";
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatIconModule } from "@angular/material/icon";
import { NavbarComponent } from './components/navbar/navbar.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatExpansionModule } from "@angular/material/expansion";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatListModule } from "@angular/material/list";
import { MatDialogModule } from "@angular/material/dialog";
import { MatMenuModule } from "@angular/material/menu";
import { TableHotelsComponent } from './components/table-hotels/table-hotels.component';
import { MatTableModule } from "@angular/material/table";
import { TableOffersComponent } from './components/table-offers/table-offers.component';
import { OffersComponent } from './offers/offers.component';
import { PacksComponent } from "./packs/packs.component";
import { TouristComponent } from './tourist/tourist.component';
import { AgenciesComponent } from './agencies/agencies.component';
import { ExcursionComponent } from './excursion/excursion.component';
import { TableAgenciesComponent } from './components/table-agencies/table-agencies.component';
import { TableTouristComponent } from './components/table-tourist/table-tourist.component';
import { TableExcursionComponent } from './components/table-excursion/table-excursion.component';
import { TablePacksComponent } from './components/table-packs/table-packs.component';
import { HotelsComponent } from './hotels/hotels.component';
import { CarouselComponent } from './components/carousel/carousel.component';
import { MyReservesComponent } from './my-reserves/my-reserves.component';
import { HotelService } from './components/table-hotels/hotel.service';
import { AgenciesService } from "./components/table-agencies/agencies.service";
import { TuristaService } from "./components/table-tourist/tourist.service";
import { PacksService } from "./components/table-packs/packs.service";
import { ExcursionService } from "./components/table-excursion/excursion.service";
import { TableOffersService } from "./components/table-offers/table-offers.service";
import { MatNativeDateModule } from "@angular/material/core";
import { TableReservesComponent } from './components/table-reserves/table-reserves.component';
import { ReserveService } from './components/reserve/reserve.service';
import { TouristsTabComponent } from './components/tourists/tourists.component';
import { ExcursionsTabComponent } from './components/excursions/excursions.component';
import {PacksTabComponent} from "./components/packs/packs.component";
import {HotelsTabComponent} from "./components/hotels/hotels.component";
import {HotelsTabService} from "./components/hotels/hotels.service";
import {PacksTabService} from "./components/packs/packs.service";
import {TouristsTabService} from "./components/tourists/tourists.service";
import {ExcursionsTabService} from "./components/excursions/excursions.service";

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ReserveComponent,
    NavbarComponent,
    TableHotelsComponent,
    TableOffersComponent,
    OffersComponent,
    PacksComponent,
    TouristComponent,
    AgenciesComponent,
    ExcursionComponent,
    TableAgenciesComponent,
    TableTouristComponent,
    TableExcursionComponent,
    TablePacksComponent,
    HotelsComponent,
    HotelsTabComponent,
    CarouselComponent,
    MyReservesComponent,
    TableReservesComponent,
    TouristsTabComponent,
    ExcursionsTabComponent,
    PacksTabComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    routing,
    FormsModule,
    HttpClientModule,
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
    MatDialogModule,
    MatMenuModule,
    MatTableModule,
    MatDatepickerModule,
    ReactiveFormsModule,
    MatNativeDateModule
  ],
  providers: [HotelService, AgenciesService, TuristaService, PacksService, ExcursionService,
    TableOffersService, ReserveService, HotelsTabService, PacksTabService, TouristsTabService, ExcursionsTabService],
  bootstrap: [AppComponent]
})
export class AppModule { }
