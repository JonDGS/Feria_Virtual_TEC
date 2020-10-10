import {Component, Input, OnInit} from '@angular/core';
import {Producer} from '../../../models/producer.model';
import {ServerService} from '../../../server.service';

@Component({
  selector: 'app-producer-details',
  templateUrl: './producer-details.component.html',
  styleUrls: ['./producer-details.component.css']
})
export class ProducerDetailsComponent implements OnInit {
  @Input() producer: Producer;

  constructor() { }

  ngOnInit(): void {
  }
}
