import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AppComponent} from "./app.component";
import {HomeComponent} from "./home/home.component";
import {OffersComponent} from "./offers/offers.component";
import {PacksComponent} from "./packs/packs.component";
import {ExcursionComponent} from "./excursion/excursion.component";
import {AgenciesComponent} from "./agencies/agencies.component";
import {TouristComponent} from "./tourist/tourist.component";
import {HotelsComponent} from "./hotels/hotels.component";
import {MyReservesComponent} from "./my-reserves/my-reserves.component";

const appRoutes = [
  { path: "", component: HomeComponent, pathMatch: "full" },
  { path: "home", component: HomeComponent, pathMatch: "full" },
  { path: "hotels", component: HotelsComponent, pathMatch: "full" },
  { path: "packs", component: PacksComponent, pathMatch: "full" },
  { path: "excursion", component: ExcursionComponent, pathMatch: "full" },
  { path: "agencies", component: AgenciesComponent, pathMatch: "full" },
  { path: "tourist", component: TouristComponent, pathMatch: "full" },
  { path: "myreserves", component: MyReservesComponent, pathMatch: "full" },
  { path: "offers", component: OffersComponent, pathMatch: "full" }

];

export const routing = RouterModule.forRoot(appRoutes);
