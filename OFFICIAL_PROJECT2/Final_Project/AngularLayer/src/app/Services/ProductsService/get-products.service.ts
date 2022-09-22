import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from 'src/app/Models/Models';

@Injectable({
  providedIn: 'root'
})
export class GetProductsService {

  constructor(public product:Product, public http: HttpClient) { 
    this.http;
  }
  private APIURL:string = 'https://localhost:7116';

  public getALLProducts(): Observable<Product[]>
  {
    return this.http.get<Product[]>(this.APIURL + '/Product');
  }
}
