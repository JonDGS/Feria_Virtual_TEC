import { ServerService } from './../../server.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'form-producer',
  templateUrl: './form-producer.component.html',
  styleUrls: ['./form-producer.component.css'],
})
export class FormProducerComponent implements OnInit {
  constructor(server: ServerService) {
    //codigo de prueba para meter un registro de productor en la lista de requests de productores del server
    //server.addProducerRequest({ id: 0, name: 'producer1' });
    //console.log(server.producerRequests());
  }

  ngOnInit(): void {}
}
