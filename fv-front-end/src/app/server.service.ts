import {EventEmitter, Injectable, Output, setTestabilityGetter} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Category} from './models/category.model';
import {Producer} from './models/producer.model';

@Injectable({
  providedIn: 'root',
})
export class ServerService {
  // producers requests array to save resquests injected by the form
  producersRequestsObj: { id: number; name: string }[] = [];

  //token for users login
  private token;

  // Admin view
  @Output() producerSelected = new EventEmitter<Producer>();
  // category list for storing the categories made by the user
  categoryList: Category[] = [
    new Category('verduras', 1),
    new Category('frutas', 2)
  ];
  categoryID = 1;
  producerList: Producer[] = [
    new Producer(117730762, 'Alvaro', 'Vargas', 'Heredia, Belen, La Rivera', '3/4/2020', 85787059, 85787059, 'Heredia Centro', 'AVargasM', '123abc','examle@asdf.com'),
    new Producer(123456789, 'Jose', 'Ferrer', 'San Jose, Escazu, Escazu', '8/11/1996', 20329875, 55896321, 'Ezcazu', 'uyt22', 'pass1word','examle@asdf.com'),
    new Producer(117730762, 'Alvaro', 'Vargas', 'Heredia, Belen, La Rivera', '3/4/2020', 85787059, 85787059, 'Heredia Centro', 'AVargasM', '123abc','examle@asdf.com'),
    new Producer(123456789, 'Jose', 'Ferrer', 'San Jose, Escazu, Escazu', '8/11/1996', 20329875, 55896321, 'Ezcazu', 'uyt22', 'pass1word','examle@asdf.com'),
    new Producer(117730762, 'Alvaro', 'Vargas', 'Heredia, Belen, La Rivera', '3/4/2020', 85787059, 85787059, 'Heredia Centro', 'AVargasM', '123abc','examle@asdf.com'),
    new Producer(123456789, 'Jose', 'Ferrer', 'San Jose, Escazu, Escazu', '8/11/1996', 20329875, 55896321, 'Ezcazu', 'uyt22', 'pass1word','examle@asdf.com')
  ];

  constructor(public http: HttpClient) {}

  addProducerRequest(producer) {
    this.producersRequestsObj.push(producer);
  }

  producerRequests() {
    return this.producersRequestsObj;
  }

  addCategory(category){
    this.categoryList.push(category);
    this.categoryID++;
  }

  getProducers(){
    return this.producerList.slice();
  }

  register(){
    this.http.post('http://localhost:55172/api/Register/Admin?user=sergio&email=sergio@admin.com&password=hola1234',"").subscribe(response=>{
      console.log(response)
    })
  }
  login(username,email,password){
    this.http.post(`http://localhost:55172/api/LogIn?user=${username}&email=${email}&password=${password}`,"").subscribe(res=>{
      console.log(res)
      this.token = res;
    })
  }

  products(){
    return this.http.get(`http://localhost:55172/api/Database/Products?token=${this.token}`)
  }
}