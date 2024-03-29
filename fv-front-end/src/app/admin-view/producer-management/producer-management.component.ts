import { Component, OnInit } from '@angular/core';
import {Producer} from '../../models/producer.model';
import {ServerService} from '../../server.service';

@Component({
  selector: 'app-producer-management',
  templateUrl: './producer-management.component.html',
  styleUrls: ['./producer-management.component.css']
})
/**
 * This component holds the info related to the producer management of the admin
 */
export class ProducerManagementComponent implements OnInit {
  selectedProducer: Producer;

  constructor(private serverService: ServerService) { }

  ngOnInit(): void {
    this.serverService.producerSelected.subscribe(
      (producer: Producer) => {
        this.selectedProducer = producer;
      }
    );
  }

}
