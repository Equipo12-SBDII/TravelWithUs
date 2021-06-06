import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Excursion} from "./excursions";

@Injectable({
  providedIn: 'root'
})
export class ExcursionsTabService {
  private dataPath = 'https://localhost:5001/api/excursion';

  constructor(private http: HttpClient) { }

  GetExcursion() {
    return this.http.get<Excursion[]>(this.dataPath);
  }

}
