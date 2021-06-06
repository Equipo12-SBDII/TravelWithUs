import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Hotel} from "../table-hotels/hotel.model";

@Injectable({
  providedIn: 'root'
})
export class HotelsTabService {
  private dataPath = 'https://localhost:5001/api/hotel';

  constructor(private http: HttpClient) { }

  GetHotel() {
    return this.http.get<Hotel[]>(this.dataPath);
  }
}
