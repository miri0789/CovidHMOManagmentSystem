import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Client } from '../client';
import { ClientsService } from '../clients.service';

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.scss']
})
export class ClientListComponent implements OnInit, OnDestroy {
  clients: Client[] = [];
  error = null;
  private subscriber = new Subscription();


  constructor(private clientsService: ClientsService) { }

  ngOnInit(): void {
    this.subscriber.add(
      this.clientsService.getClients().subscribe(
        clients => this.clients = clients));
  }

  ngOnDestroy(): void {
    this.subscriber.unsubscribe();
  }

}
