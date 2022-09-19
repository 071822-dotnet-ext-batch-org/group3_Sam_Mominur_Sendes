import { Component, OnInit } from '@angular/core';
import { CartComponent } from 'src/app/AllComponents/cart/cart.component';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  constructor(Cart: CartComponent) { }

  ngOnInit(): void {
  }

}
