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

  constructor(public server: ServerService) {
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
      this.producerForm.value.newProducerPassword,
      ''
    );

    this.server.registerProducer(this.producer.user,this.producer.email,this.producer.password,this.producer.id,this.producer.name,this.producer.lastName,this.producer.lastName,this.producerForm.value.location.newProducerProvince ,this.producerForm.value.location.newProducerCanton,this.producerForm.value.location.newProducerDistrict,"01","01","2000",this.producer.phone,this.producer.sinpe,this.producer.deliveryLocation)
  }
}
