import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../Models/Products';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

//This is the localhost port of the API, Where the server requests with route to when running
private APIURL = 'https://localhost:7116';

// private currentUser : User = {id : "00000000-0000-0000-0000-000000000000", username : 'Dr. Not', password: 'Pass0', firstname: 'First', lastname: 'Last', Email:'default@email.com', Role: 'User', SignUpDate: Date.now};

// private client = HttpClient;
//Where we will add functionality/logic to send and receive requests to API
//SO we are gonna use a private HttpClient, and will call it http
//We include it in the constructor to let the CLASS know what an HttpClient is
constructor(private http: HttpClient) { this.http; }
//We will WAIT for the products by specifying that we'll need an Observable (Like a Promise in c#)
//The Observable is EXPECTING a return TYPE
public getProducts(): Observable<Product[]>//We'll need to create a DTO wilth properties to store the product information
{
  //Specify HOW this HTTP service should send and receive a request
  //The httpClient will send the get request to the API
  return this.http.get<Product[]>(this.APIURL + '/Product');
}

  
}
