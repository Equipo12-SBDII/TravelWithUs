import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Oferta } from '../reserve/reserve';
import { Observable } from "rxjs";

@Injectable()
export class TableOffersService {
  private dataPath = 'https://localhost:5001/api/request/ofertaReserva';

  constructor(private http: HttpClient) { }

  GetOferta() {
    return this.http.get<Oferta[]>(this.dataPath);
  }

}
