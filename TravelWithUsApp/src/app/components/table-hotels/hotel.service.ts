import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Hotel } from './hotel.model';
import { Observable } from "rxjs";

@Injectable()
export class HotelService {
  private dataPath = 'https://localhost:5001/api/hotel';

  constructor(private http: HttpClient) { }

  GetHotel() {
    return this.http.get<Hotel[]>(this.dataPath);
  }

}
