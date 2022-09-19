import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { Product } from 'src/app/Models/Products';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  //This is what we are getting back from the request - Because JS is dynamically typed, any type can be passed in the request
  // public  static DictionaryOf_allProducts =  {};
  public allProducts?: Product[] = []

  public currentProduct?: Product 
  // public product?: Product = {

  // }
  // product: Product;
  // private currentUser : User = {id : "00000000-0000-0000-0000-000000000000", username : 'Dr. Not', password: 'Pass0', firstname: 'First', lastname: 'Last', Email:'default@email.com', Role: 'User', SignUpDate: Date.now};
  // private currentUser_Login: User_LoginDTO = { email:'default@email.com', password: 'Pass0'}
  // private currentUser_Register: User_RegisterDTO = { username : 'Dr. Not', password: 'Pass0', firstname: 'First', lastname: 'Last', Email:'default@email.com'}
  // private currentUser_Guest: User_Guest = { firstname: 'First', lastname: 'Last', Email:'default@email.com'}
  constructor(public ProductService: ProductService ) { }

  ngOnInit(): void {
    this.displayProducts()
  }


  //Products
  displayProducts()
  {
    //http request returns an Observable. So we subscribe the Observable to get and use that data
    this.ProductService.getProducts().subscribe(ListOfProducts =>
      {

        console.log(ListOfProducts.length)


        for(let product of ListOfProducts){
          this.currentProduct = product

          // let obj = {
          //   "id": this.currentProduct.id,
          //   "title": this.currentProduct.title,
          //   "description": this.currentProduct.description,
          //   "price": this.currentProduct.price,
          //   "inventory": this.currentProduct.inventory,
          //   "dateCreated": this.currentProduct.dateCreated
          // };
          
          
          console.log(this.currentProduct)

          this.allProducts?.push(this.currentProduct);
          // ProductsComponent.DictionaryOf_allProducts[`${obj.id}`] = obj;
          // this.DictionaryOf_allProducts.set( product.title , product )  //JSON.stringify(data) ;
          const productTOCART = this.currentProduct;
          localStorage.setItem(JSON.stringify(productTOCART.id), JSON.stringify(productTOCART) )
          this.currentProduct = undefined;

        }
      })
  }

  hideProducts()
  {
    this.allProducts?.splice(0) ;
  }

  addToCart(id:any):void{
    if(this.allProducts != null){
      for(let product of this.allProducts){
        // count++;
        // let Prod_id = product.id
        console.log(`This is the Passed in ID: ${id} - Prod ID to check for: ${product.id}`)
        if(id == product.id){
          sessionStorage.setItem(JSON.stringify(id), JSON.stringify(product))
          alert(`This ${product.title} has been added to your cart`)
        }

    }
    }
    // if(this.product != null){
    // }

  }
}
