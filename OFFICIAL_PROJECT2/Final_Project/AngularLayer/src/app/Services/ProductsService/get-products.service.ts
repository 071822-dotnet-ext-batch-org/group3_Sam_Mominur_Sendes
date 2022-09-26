import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from 'src/app/Models/Models';

@Injectable({
  providedIn: 'root'
})
export class GetProductsService {

  public product:Product = {}
  public static cart: Product[] = []
  public static cartTotal?: number
  
  constructor( private http: HttpClient) { 
    this.http;
    this.product;
  }
  private APIURL:string = 'https://localhost:7116';

  
  public getALLProducts(): Observable<Product[]>
  {
    let allProd = this.http.get<Product[]>(this.APIURL + '/Product');
    return allProd;
  }//END OF GET PRODUCTS

  public sendProduct(product:Product):void{
    this.product = product;
    console.log(`Product ${product.title} is now in the service and ready to be sent`);
  }//END OF SET PRODUCT

  public getProduct(){
    return this.product;
  }//END OF GET PRODUCT

  public addToCart(product:Product):void{
    if(sessionStorage.length < 1){
      //Empty cart
      console.log(`The service cart is empty`)
    }else{
      //Cart will items already
      for(let prod of GetProductsService.cart)
      {
        if(prod.id != product.id)
        {
          console.log(`The service is adding product ${prod.title} to the service cart`)
          GetProductsService.cart.push(product);
        }
      }
    }
  }//END OF ADD TO CART

  public getCart():Product[]{
    console.log(`SessionStaorage has: ${sessionStorage.length} items`)
    if(sessionStorage.length < 1){
      //Empty cart
      console.log(`The service cart is empty`)
      return GetProductsService.cart;
    }else{
      //Cart will items already
      for(let i:number = 0; i < sessionStorage.length; i++)
      {
        // GetProductsService.cart.push()
        const id: any = sessionStorage.key(i)
        const obj: any = sessionStorage.getItem(id)
        const prod: Product = JSON.parse(obj)
        
        console.log(prod)
        GetProductsService.cart.push(prod)
      }
      return GetProductsService.cart;
    }
  }//END OF GET CART
}
