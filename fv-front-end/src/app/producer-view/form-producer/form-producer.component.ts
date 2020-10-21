import { ServerService } from './../../server.service';
import {Component, OnInit, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {Producer} from '../../models/producer.model';

@Component({
  selector: 'form-producer',
  templateUrl: './form-producer.component.html',
  styleUrls: ['./form-producer.component.css'],
})
export class FormProducerComponent implements OnInit {
  @ViewChild('newProducerForm') producerForm: NgForm;
  producer: Producer;
  address: string;

  constructor(server: ServerService) {
    // codigo de prueba para meter un registro de productor en la lista de requests de productores del server
    // server.addProducerRequest({ id: 0, name: 'producer1' });
    // console.log(server.producerRequests());
  }

  ngOnInit(): void {}

  onSubmit(){
    // tslint:disable-next-line:max-line-length
    this.address = this.producerForm.value.location.newProducerProvince + ', ' +
                   this.producerForm.value.location.newProducerCanton + ', ' +
                   this.producerForm.value.location.newProducerDistrict;

    this.producer = new Producer(
      this.producerForm.value.newProducerID,
      this.producerForm.value.fullName.newProducerName,
      this.producerForm.value.fullName.newProducerLastName,
      this.address,
      this.producerForm.value.newProducerBirthday,
      this.producerForm.value.newProducerPhone,
      this.producerForm.value.newProducerSINPE,
      this.producerForm.value.newProducerDeliveryLocation,
      this.producerForm.value.newProducerUsername,
      this.producerForm.value.newProducerPassword
    );

    console.log(this.producer);
  }
}
