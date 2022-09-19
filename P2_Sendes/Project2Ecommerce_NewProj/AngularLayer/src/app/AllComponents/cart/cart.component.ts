import { Component, OnInit } from '@angular/core';
import { User } from '@auth0/auth0-angular';
import { Product } from '../../Models/Products'; 

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  // public cart: any
  constructor() { }
  public currentCart?: Product[] = []

  ngOnInit(): void {
    this.getCart()
  }

  getCart(){
    //Get Cart
    for(let item in sessionStorage){
      console.log(`Cart length: ${sessionStorage.length}, Item: ${item}`)
      let myCartProductOBJ = sessionStorage[item];
      console.log(`This is a product in cart: ${myCartProductOBJ}`)
      this.currentCart?.push(JSON.parse(myCartProductOBJ));
      
    }
    // for(let item in sessionStorage)
    //   this.currentCart?.set(item)
    
  }


  checkout(){

  }

}
