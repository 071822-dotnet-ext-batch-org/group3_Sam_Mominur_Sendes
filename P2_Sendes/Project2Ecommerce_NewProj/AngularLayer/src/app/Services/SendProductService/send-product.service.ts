import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Product } from 'src/app/Models/Products';

@Injectable({
  providedIn: 'root'
})
export class SendProductService {
  // emptyProd: Product = {};
  
  // behavior subject that will hold current value of the message sent from other component to this service
  private productSource = new BehaviorSubject<any>(""); 
  currentProduct = this.productSource.asObservable()// variable of the message to be used by another component
  constructor() { }

  //A function that calls next on the behavior subject to change its value to the new product
  loadProduct(product: Product){
    this.productSource.next(product)
  }
}
