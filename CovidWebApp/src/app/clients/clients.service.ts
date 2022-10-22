import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ClientsService {

  constructor(private http: HttpClient) {
  }


  getCards(appId: number): Observable<Card[]> {
    return this.http.get<Card[]>(`api/cards/${appId}`);
  }
}