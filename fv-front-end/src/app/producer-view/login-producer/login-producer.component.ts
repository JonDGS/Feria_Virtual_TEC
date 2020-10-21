import { NgForm } from '@angular/forms';
import { ServerService } from './../../server.service';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'login-producer',
  templateUrl: './login-producer.component.html',
  styleUrls: ['./login-producer.component.css'],
})
export class LoginProducerComponent implements OnInit {
  @ViewChild('newProducerForm') producerForm: NgForm;
  constructor(private server: ServerService) {}

  ngOnInit(): void {}

  login(){
    
    let username = this.producerForm.value.username;
    let mail = this.producerForm.value.mail;
    let password = this.producerForm.value.password;
    this.server.login(username,mail,password)
  }
}
