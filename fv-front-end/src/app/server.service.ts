import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ServerService {
  //producers requests array to save resquests injected by the form
  producersRequestsObj: { id: number; name: string }[] = [];

  constructor() {}

  addProducerRequest(producer) {
    this.producersRequestsObj.push(producer);
  }

  producerRequests() {
    return this.producersRequestsObj;
  }
}
