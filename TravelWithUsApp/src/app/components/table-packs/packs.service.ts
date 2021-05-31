import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Paquete } from './packs';
import { Observable } from "rxjs";

@Injectable()
export class PacksService {
  private dataPath = 'https://localhost:5001/api/paquete';

  constructor(private http: HttpClient) { }

  GetPaquete() {
    return this.http.get<Paquete[]>(this.dataPath);
  }

}
