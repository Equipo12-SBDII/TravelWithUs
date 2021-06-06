import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Reserve, Turista, Agencia, Oferta, Reservaind } from './reserve';
import { map } from 'rxjs/operators';

@Injectable()
export class ReserveService {
  private getPathTurista = 'https://localhost:5001/api/request/turistaReserva';
  private getPathOferta = 'https://localhost:5001/api/request/ofertaReserva';
  private getPathAgencias = 'https://localhost:5001/api/request/agenciaReserva';
  private postPath = 'https://localhost:5001/api/reservaIndividual';
  private path = 'https://localhost:5001/api/request/individualReservation';
  constructor(private http: HttpClient) { }

  GetAgencies() {
    return this.http.get<Agencia[]>(this.getPathAgencias);
  }
  GetOffers() {
    return this.http.get<Oferta[]>(this.getPathOferta);
  }
  GetTourists() {
    return this.http.get<Turista[]>(this.getPathTurista);
  }

  GetData() {
    return this.http.get<Reserve>(this.path);
  }

  PostReservaIndividual(data: Reservaind) {
    return this.http.post(this.postPath, data);
  }

  //   {
  //     "agenciaID": 9,
  //     "turistaID": 1,
  //     "hotelID": 4,
  //     "ofertaID": 2,
  //     "acompanantes": 3,
  //     "aerolinea": "lapiraAirlines",
  //     "precio": 230.00,
  //     "llegada": "2022-03-10",
  //     "salida": "2022-04-01",
  //     "turista": null,
  //     "agencia": null,
  //     "oferta": null
  // }
}
