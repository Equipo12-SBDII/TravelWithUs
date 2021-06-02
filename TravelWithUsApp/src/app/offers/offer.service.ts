import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { from } from "rxjs";

import { Offer } from './offer.model'

@Injectable({
  providedIn: 'root'
})
export class OfferService {
  private serverPath = 'https://localhost:5001/api/oferta'
  constructor(private http: HttpClient) {

  }

  getData() {
    return this.http.get<Offer[]>(this.serverPath);
  }

}
