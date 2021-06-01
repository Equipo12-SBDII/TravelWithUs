import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Oferta } from './offers';
import { Observable } from "rxjs";

@Injectable()
export class TableOffersService {
  private dataPath = 'https://localhost:5001/api/oferta';

  constructor(private http: HttpClient) { }

  GetOferta() {
    return this.http.get<Oferta[]>(this.dataPath);
  }

}
