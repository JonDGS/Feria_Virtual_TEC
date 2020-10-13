import { ServerService } from './../../server.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'login-producer',
  templateUrl: './login-producer.component.html',
  styleUrls: ['./login-producer.component.css'],
})
export class LoginProducerComponent implements OnInit {
  constructor(private server: ServerService) {}

  ngOnInit(): void {}

  login(){

    console.log("log in")
    this.server.testGet()
  }
}
