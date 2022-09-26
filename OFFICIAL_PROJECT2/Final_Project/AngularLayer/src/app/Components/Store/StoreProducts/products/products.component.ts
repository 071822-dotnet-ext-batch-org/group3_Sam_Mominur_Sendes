import { Component, OnInit ,EventEmitter,  Output} from '@angular/core';
import { GetProductsService } from 'src/app/Services/ProductsService/get-products.service';
import { Product } from 'src/app/Models/Models';
@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  @Output() redirect:EventEmitter<any> = new EventEmitter();
  public currentProd: Product ={} 
  public prodList: Product[] = []
  constructor(private getProductsService: GetProductsService) {
    this.currentProd;
    this.prodList;
   }

  ngOnInit(): void {
    this.get_ALLPRODUCTS()
  }

  get_ALLPRODUCTS(){
    this.getProductsService.getALLProducts().subscribe(
      listOfProducts => {
        this.prodList = listOfProducts
        for(let i of this.prodList){
          console.log(`This product is : ${i.title}`)
        }
        return this.prodList;
      }
    )
    return this.prodList
  }//END OF GET ALL PROD

  viewProduct(product:Product):void{
    this.currentProd = product
    this.getProductsService.sendProduct(product);
    console.log(`This product being sent to view product is : ${this.currentProd.title}`)
    this.redirect.emit(this.currentProd)

  }

  addToCart(product:Product):void{
    for( let prod of GetProductsService.cart){
      if(product.id != prod.id)
      console.log(`This product has been added to cart ${product.title}`)
      this.getProductsService.addToCart(product)

    }
  }

}
