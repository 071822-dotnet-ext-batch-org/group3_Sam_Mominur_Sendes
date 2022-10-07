import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';
import { Product } from 'src/app/Models/Products';
import { SendProductService } from 'src/app/Services/SendProductService/send-product.service';

import { Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css']
})
export class StoreComponent implements OnInit {
  
    @Input() allProducts?: Product[] = []
    @Output() add_TOPRODUCTEVENT = new EventEmitter<Product>()
    currentProduct: Product = {}
    loadedProduct: Product = {}

  constructor(public ProductService: ProductService, public SendProdService:  SendProductService) {
    this.allProducts;
    this.currentProduct;
    this.loadedProduct;
   }

  ngOnInit(): void {
    this.displayProducts()
    this.SendProdService.currentProduct.subscribe(product => this.currentProduct = product)
  }

  //Products
  displayProducts()
  {
    //http request returns an Observable. So we subscribe the Observable to get and use that data
    this.ProductService.getProducts().subscribe(ListOfProducts =>
      {

        console.log(`${ListOfProducts.length} Products to Display`)
        


        for(let product of ListOfProducts){
          console.log(product)

          this.loadedProduct = product

          this.allProducts?.push(product);
          localStorage.setItem(`${this.loadedProduct.ID}`, JSON.stringify(this.loadedProduct) )
        }
      })
  }

  hideProducts()
  {
    this.allProducts?.splice(0) ;
  }
  viewProductDetails(){
    console.log(`THis is the product sent to the function to view prod: ${this.currentProduct?.Title}`)
    // if(this.allProducts !== undefined){
    //   for(let product of this.allProducts){
    //     if(product.ID === productID){
    //       this.currentProduct = product
    this.currentProduct;
    if((this.currentProduct !== null) && (this.currentProduct !== undefined))
    {
      this.add_TOPRODUCTEVENT.emit(this.currentProduct)//Sends product to cart
      this.SendProdService.loadProduct(this.currentProduct)

      console.log(`THis is the product sent to the Product Page: ${this.currentProduct.Title}`)
    }
  }//END VIEW PRODUCT DETAILS

}
