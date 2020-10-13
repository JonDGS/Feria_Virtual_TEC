import {Component, Input, OnInit} from '@angular/core';
import {Producer} from '../../../../models/producer.model';
import {ServerService} from '../../../../server.service';

@Component({
  selector: 'app-producer-item',
  templateUrl: './producer-item.component.html',
  styleUrls: ['./producer-item.component.css']
})
export class ProducerItemComponent implements OnInit {
  @Input() producer: Producer;

  constructor(private serverService: ServerService) { }

  ngOnInit(): void {
  }

  onSelected(){
    this.serverService.producerSelected.emit(this.producer);
  }
}
