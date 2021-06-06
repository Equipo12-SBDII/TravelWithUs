import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Reserva } from "./reserveIndividual";

@Injectable({
  providedIn: 'root'
})
export class TableReservesService {
  private dataPath = 'https://localhost:5001/api/request/reservasInd';

  constructor(private http: HttpClient) { }

  GetReservaIndividual() {
    return this.http.get<Reserva[]>(this.dataPath);
  }


}
