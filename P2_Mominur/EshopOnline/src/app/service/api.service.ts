
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {map} from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http : HttpClient) { }

  getProduct(){
 
    /*
    fetch('https://localhost:7182/api/Ecom/ProductsAsync',
    {
      method: 'GET',
      headers:  { 'Content-Type': 'application/json' },
      mode: 'cors',
      
    })
    .then(res => {
      if (res.ok) {
        return res.json;
        
      }
      else{
         console.log("IT was not working");
         
      }
    })
    */
 


 var print = this.http.get<any>("https://fakestoreapi.com/products")
    .pipe(map((res:any)=>{
      return res;
    }))
      console.log(`This is the return data: $typeof(print)`);
      return print;
 
  }


  
}  