import {Component, Input, OnInit} from '@angular/core';
import {Producer} from '../../../../models/producer.model';
import {ServerService} from '../../../../server.service';

@Component({
  selector: 'app-producer-item',
  templateUrl: './producer-item.component.html',
  styleUrls: ['./producer-item.component.css']
})
/**
 * This is an item of the producer list and shows some basic info of the producer that it contains
 */
export class ProducerItemComponent implements OnInit {
  @Input() producer: Producer;

  constructor(private serverService: ServerService) { }

  ngOnInit(): void {
  }

  /**
   * Ths method emits an event when a producer item from the producer list was selected
   */
  onSelected(){
    this.serverService.producerSelected.emit(this.producer);
  }
}
