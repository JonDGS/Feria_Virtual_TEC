import { Component, OnInit } from '@angular/core';
import {ServerService} from '../../../server.service';
import {Producer} from '../../../models/producer.model';

@Component({
  selector: 'app-producer-list',
  templateUrl: './producer-list.component.html',
  styleUrls: ['./producer-list.component.css']
})
/**
 * This component holds a list of producers item from which the admin can select specific items
 */
export class ProducerListComponent implements OnInit {
  producers: Producer[];

  constructor(private serverService: ServerService) { }

  ngOnInit(): void {
    this.producers =  this.serverService.getProducers();
  }

}
