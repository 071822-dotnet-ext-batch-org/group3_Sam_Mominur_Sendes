import { Component, OnInit } from '@angular/core';
import { GetProductsService } from 'src/app/Services/ProductsService/get-products.service';
import { Product, Cart } from 'src/app/Models/Models';
@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  public cart: Cart = {}
  
  constructor(private GetProdService: GetProductsService) { 
    // this.cart;
  }
  
  ngOnInit(): void {
    let currentCart = this.GetProdService.getCart();
    this.cart.cart = currentCart ;
  }

}
