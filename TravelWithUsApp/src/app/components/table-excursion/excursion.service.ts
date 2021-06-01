import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Excursion } from './excursion';
import { Observable } from "rxjs";

@Injectable()
export class ExcursionService {
  private dataPath = 'https://localhost:5001/api/excursion';

  constructor(private http: HttpClient) { }

  GetExcursion() {
    return this.http.get<Excursion[]>(this.dataPath);
  }

}

