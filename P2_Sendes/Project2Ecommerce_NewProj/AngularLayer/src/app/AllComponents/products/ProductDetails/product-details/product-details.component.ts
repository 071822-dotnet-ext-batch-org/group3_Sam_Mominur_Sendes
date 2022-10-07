import { Component, OnInit } from '@angular/core';
import { Input, Output } from '@angular/core';
import { ProductsComponent } from '../../products.component';
import { Product } from 'src/app/Models/Products';


@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  @Input() DetailedProduct?: Product 

  constructor() { }

  ngOnInit(): void {
  }
  getProduct($event: Product){
    this.DetailedProduct = $event;
    this.displayProduct()
  }
  displayProduct(){
    return this.DetailedProduct;
  }

  // addToCart(id:any):void{
  //   if(this.allProducts != null){
  //     for(let product of this.allProducts){
  //       this.currentProduct = product;
  //       // count++;
  //       // let Prod_id = product.id
  //       console.log(`This is the Product ID Passed in: ${id} - Prod ID in ALLPRODUCTS to check for: ${this.currentProduct.ID}`)
  //       if(id == this.currentProduct.ID){
  //         this.add_TOPRODUCTEVENT?.emit(this.currentProduct)//Sends product to cart
  //         sessionStorage.setItem(`${this.currentProduct.ID}`, JSON.stringify(this.currentProduct))
  //         alert(`This ${this.currentProduct.Title} has been added to your cart`)
  //       }
  //     }
  //   }
  // }//END OF ADD TO CART

}
