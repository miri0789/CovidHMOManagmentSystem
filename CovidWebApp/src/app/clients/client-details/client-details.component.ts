import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Client } from '../client';
import { ClientsService } from '../clients.service';

const phonePattern = /\(?([0-9]{2,3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/;
const digitsPattern = /^\d+$/;

@Component({
  selector: 'app-client-details',
  templateUrl: './client-details.component.html',
  styleUrls: ['./client-details.component.scss']
})
export class ClientDetailsComponent implements OnInit, OnDestroy {
  isNew: boolean = false;
  client: Client;
  patientsForm: FormGroup;
  private subscriber = new Subscription();

  constructor(private fb: FormBuilder,
    private clientsService: ClientsService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id')) || -1;
    this.isNew = id === -1;
    if (this.isNew) {
      this.buildForm();
    } else {
      this.subscriber.add(this.clientsService.getClient(id).
        subscribe({
          next: client => {
            this.client = client;
            this.buildForm();
          },
          error: err => alert('An error occurred, please try again later...')
        }));
    }
  }

  private buildForm() {
    this.patientsForm = this.fb.group({
      firstName: [this.client?.firstName, Validators.required],
      lastName: [this.client?.lastName, Validators.required],
      identity: [this.client?.identity, [Validators.required,]],
      city: [this.client?.city, Validators.required],
      street: [this.client?.street, Validators.required],
      buildingNumber: [this.client?.buildingNumber, [Validators.required, Validators.pattern(digitsPattern)]],
      phoneNumber: [this.client?.phoneNumber, Validators.pattern(phonePattern)],
      mobileNumber: [this.client?.mobileNumber, [Validators.required, Validators.pattern(phonePattern)]],
      recoveryDate: this.client?.recoveryDate,
      positiveResultDate: this.client?.positiveResultDate,
    });

  }


  save() {
    if (this.patientsForm.valid) {
      const client = this.patientsForm.value;
      client.clientId = this.client?.clientId;

      this.subscriber.add(
        (this.isNew ? this.clientsService.addClient(this.patientsForm.value) :
          this.clientsService.updateClient(this.patientsForm.value)).
          subscribe({
            next: () => {
              alert('The patient saved successfuly');
              this.back();
            },
            error: err => alert('An error occurred, please try again later...')
          }));
    }
  }


  back() {
    this.router.navigate(['clients']);
  }

  ngOnDestroy(): void {
    this.subscriber.unsubscribe();
  }

}
