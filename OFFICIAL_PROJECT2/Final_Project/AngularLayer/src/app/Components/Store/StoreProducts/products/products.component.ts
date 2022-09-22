import { Component, OnInit } from '@angular/core';
import { GetProductsService } from 'src/app/Services/ProductsService/get-products.service';
import { Product } from 'src/app/Models/Models';
@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  constructor(private getProductsService: GetProductsService, public currentProd: Product, public prodList: Product[]) { }

  ngOnInit(): void {
    this.get_ALLPRODUCTS()
  }

  get_ALLPRODUCTS(){
    this.getProductsService.getALLProducts().subscribe(
      listOfProducts => this.prodList = listOfProducts
    )
    return this.prodList
  }

}
