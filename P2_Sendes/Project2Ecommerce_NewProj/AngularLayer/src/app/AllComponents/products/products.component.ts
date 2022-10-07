import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import { Output } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { Product } from 'src/app/Models/Products';
import { SendProductService } from 'src/app/Services/SendProductService/send-product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

   currentProduct: Product = {}
  constructor(public ProductService: ProductService, public SendProdService:  SendProductService) { }

  ngOnInit(): void {
    // this.displayProduct()
    this.SendProdService.currentProduct.subscribe(product => 
      {
        console.log(`About to load prod: ${product}`);
        this.currentProduct = product;
        console.log(`The loaded prod is: ${this.currentProduct.Title}`);
      })
  }


  //Products
  getProduct($event : Product)
  {
    this.currentProduct = $event;
  }
}
