import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AppComponent} from "./app.component";
import {LoginComponent} from "./login/login.component";
import {RegisterComponent} from "./register/register.component";
import {HomeComponent} from "./home/home.component";
import {HotelpageComponent} from "./hotelpage/hotelpage.component";
import {OffersComponent} from "./offers/offers.component";

const appRoutes = [
  { path: "", component: LoginComponent, pathMatch: "full" },
  { path: "login", component: LoginComponent, pathMatch: "full" },
  { path: "register", component: RegisterComponent, pathMatch: "full" },
  { path: "home", component: HomeComponent, pathMatch: "full" },
  { path: "hotelpage", component: HotelpageComponent, pathMatch: "full" },
  { path: "offers", component: OffersComponent, pathMatch: "full" }

];

export const routing = RouterModule.forRoot(appRoutes);
