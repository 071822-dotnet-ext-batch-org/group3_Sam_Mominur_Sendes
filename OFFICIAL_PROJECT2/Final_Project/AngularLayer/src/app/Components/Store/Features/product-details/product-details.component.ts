import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { GetProductsService } from 'src/app/Services/ProductsService/get-products.service';
import { Product } from 'src/app/Models/Models';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  public product: Product = {}

  constructor(private GetProdService: GetProductsService) { 
    this.product;
  }

  ngOnInit(): void {
    this.showProduct();
  }
  showProduct(): Product{
    this.product = this.GetProdService.getProduct();
    console.log(`The viewed product is : ${this.product.title}`)
    return this.product;
  }
  addToCart(){
    sessionStorage.setItem(JSON.stringify(this.product.id), JSON.stringify(this.product))
    this.GetProdService.addToCart(this.product);
    console.log(`This product being sent to cart is : ${this.product.title}`)
  }
}
