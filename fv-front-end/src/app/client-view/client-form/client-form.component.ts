import { ServerService } from './../../server.service';
import {Component, OnInit, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import { Server } from 'http';
import {Client} from '../../models/client.model';
import {Producer} from '../../models/producer.model';

@Component({
  selector: 'client-form',
  templateUrl: './client-form.component.html',
  styleUrls: ['./client-form.component.css']
})
export class ClientFormComponent implements OnInit {
  @ViewChild('newClientForm') clientForm: NgForm;
  client: Client;
  address;

  constructor(public server: ServerService) { }

  ngOnInit(): void {
  }

  onSubmitClient(){
    this.address = this.clientForm.value.location.newClientProvince + ', ' +
      this.clientForm.value.location.newClientCanton + ', ' +
      this.clientForm.value.location.newClientDistrict;

    this.client = new Client(
      this.clientForm.value.newClientID,
      this.clientForm.value.fullName.newClientName,
      this.clientForm.value.fullName.newClientLastName,
      this.address,
      this.clientForm.value.newClientBirthday,
      this.clientForm.value.newClientPhone,
      this.clientForm.value.newClientUsername,
      this.clientForm.value.newClientPassword,
      this.clientForm.value.newClientEmail
    );

    this.server.registerClient(this.client.user,this.clientForm.value.newClientEmail,this.client.password,this.client.id,this.client.name,this.client.lastName,this.client.lastName,this.clientForm.value.location.newProducerProvince ,this.clientForm.value.location.newProducerCanton,this.clientForm.value.location.newProducerDistrict,"01","01","2000",this.client.phone)

    
  }

}
