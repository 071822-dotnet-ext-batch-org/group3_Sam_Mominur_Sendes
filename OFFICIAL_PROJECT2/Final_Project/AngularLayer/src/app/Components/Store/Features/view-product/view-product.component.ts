import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { GetProductsService } from 'src/app/Services/ProductsService/get-products.service';
import { Product } from 'src/app/Models/Models';

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.css']
})
export class ViewProductComponent implements OnInit {
  @Input() product:Product = {}
  constructor( ) { }

  ngOnInit(): void {
  }

}
