import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Agencia } from './agencies';
import { Observable } from "rxjs";

@Injectable()
export class AgenciesService {
  private dataPath = 'https://localhost:5001/api/agencia';

  constructor(private http: HttpClient) { }

  GetAgencia() {
    return this.http.get<Agencia[]>(this.dataPath);
  }

}
