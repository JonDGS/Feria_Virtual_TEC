import { ServerService } from './../../server.service';
import { NgForm } from '@angular/forms';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'client-log-in',
  templateUrl: './client-log-in.component.html',
  styleUrls: ['./client-log-in.component.css']
})
export class ClientLogInComponent implements OnInit {
  @ViewChild('newProducerForm') producerForm: NgForm;
  constructor(public server: ServerService) { }

  ngOnInit(): void {
  }
  login(log: string){
    
    let username = this.producerForm.value.username;
    let email = this.producerForm.value.email;
    let password = this.producerForm.value.password;
    this.server.login(username,email,password)
  }

}
