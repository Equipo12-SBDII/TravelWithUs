import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Reserve, Turista, Agencia, Oferta } from './reserve';

@Injectable()
export class ReserveService {
  private getPath = 'https://localhost:5001/api/request/individualReservation';
  private postPath = 'https://localhost:5001/api/reservaIndividual';
  constructor(private http: HttpClient) { }

  GetData() {
    return this.http.get<Reserve[]>(this.getPath);
  }
}
