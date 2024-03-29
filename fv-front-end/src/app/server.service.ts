import {EventEmitter, Injectable, Output, setTestabilityGetter} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Category} from './models/category.model';
import {Producer} from './models/producer.model';
import {Product} from './models/product';

@Injectable({
  providedIn: 'root',
})
export class ServerService {
  // producers requests array to save resquests injected by the form
  producersRequestsObj: { id: number; name: string }[] = [];

  //token for users login
  public token;

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
    new Producer(123456789, 'Jose', 'Ferrer', 'San Jose, Escazu, Escazu', '8/11/1996', 20329875, 55896321, 'Ezcazu', 'uyt22', 'pass1word','examle@asdf.com')
  ];

  constructor(public http: HttpClient) {}
/*
  funtion: addProducerRequest
  Description: add a new producer to the list of producers
  Params : producer
  Return: void
*/
  addProducerRequest(producer) {
    this.producersRequestsObj.push(producer);
  }
/*
  funtion: producerRequests
  Description: simple return the producers request obj list 
  Params : view
  Return: Producer
*/
  producerRequests() {
    return this.producersRequestsObj;
  }
/*
  funtion: addCategory
  Description: add a new category to database
  Params : category
  Return: void
*/
  addCategory(category){
    this.categoryList.push(category);
    this.categoryID++;
  }
/*
  funtion: getProducers
  Description: return the list of producers 
  Params : view
  Return: listProducers
*/
  getProducers(){
    return this.producerList.slice();
  }
/*
  funtion: register
  Description: regiter a new users to the database 
  Params : 
  Return: void
*/
  register(){
    this.http.post('http://localhost:55172/api/Register/Admin?user=sergio&email=sergio@admin.com&password=hola1234',"").subscribe(response=>{
      console.log(response)
    })
  }

/*
  funtion: login
  Description: post to request the login and get the token
  Params : username, email , password
  Return: void
*/
  login(username,email,password){
     this.http.post(`http://localhost:55172/api/LogIn?user=${username}&email=${email}&password=${password}`,"").subscribe(res=>{
      console.log(res);
      this.token = res;
    })
  }
  /*
    funtion: products
    Description: this method returns the products list by the token
    Params : view
    Return: productsList
  */
  products(){
    return this.http.get(`http://localhost:55172/api/Database/Products?token=${this.token}`)
  }
  /*
  funtion: addProduct
  Description: this method chacnge the current selecte compnent shown on the view 
  Params : view
  Return: void
*/
  addProduct(p: Product){
    this.http.post(`http://localhost:55172/api/Database/Create/Product?pName=${p.name}&category=${p.category.name}&price=${p.price}&packageMode=${p.unit}&availability=${p.availability}&token=ea4113cc-f52e-4d8c-a576-b372376d4c17`,"").subscribe(
      res=>{
        console.log(res);
      }
    );
  }
}


//private static string pathToProjectAdmin = "C:/Users/Dxnium/OneDrive - Estudiantes ITCR/TEC/DB/Tareas/TC#1/Feria_Virtual_TEC/REST_api/Database/admins.json";
//        private static string pathToProjectClient = "C:/Users/Dxnium/OneDrive - Estudiantes ITCR/TEC/DB/Tareas/TC#1/Feria_Virtual_TEC/REST_api/Database/clients.json";
 //       private static string pathToProjectSeller = "C:/Users/Dxnium/OneDrive - Estudiantes ITCR/TEC/DB/Tareas/TC#1/Feria_Virtual_TEC/REST_api/Database/sellers.json";
