import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Turista } from './tourist';
import { Observable } from "rxjs";

@Injectable()
export class TuristaService {
  private dataPath = 'https://localhost:5001/api/turista';

  constructor(private http: HttpClient) { }

  GetTurista() {
    return this.http.get<Turista[]>(this.dataPath);
  }

}
