import {Component, OnInit, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
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

  constructor() { }

  ngOnInit(): void {
  }
/*
  funtion: onSubmitClient
  Description: this method chacnge the current selecte compnent shown on the view 
  Params : 
  Return: void
*/
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
      this.clientForm.value.newClientPassword
    );

    console.log(this.client);
  }

}
