import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Client } from './client';

@Injectable({
  providedIn: 'root'
})
export class ClientsService {

  constructor(private http: HttpClient) {
  }


  getClients(): Observable<Client[]> {
    return this.http.get<Client[]>(`api/clients`);
  }
}