import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';

import { HTTP_INTERCEPTORS } from '@angular/common/http';//To intercept request and add user token to authorize getting that request
import { AuthHttpInterceptor } from '@auth0/auth0-angular';

//My Modules | Components
import { NavBarComponent } from './AllComponents/nav-bar/nav-bar.component';
import { UserComponent } from './AllComponents/user/user.component';
import { ProductsComponent } from './AllComponents/products/products.component';
import { CartComponent } from './AllComponents/cart/cart.component';
import { LoginComponent } from './AllComponents/login/login.component';
import { LogoutComponent } from './AllComponents/logout/logout.component';
import { RegisterComponent } from './AllComponents/register/register.component';
import { AuthButtonsComponent } from './AllComponents/Authentication/auth-buttons/auth-buttons.component';
import { HomeComponent } from './AllComponents/Home/home/home.component';
import { CheckoutComponent } from './AllComponents/Checkout/checkout/checkout.component';
import { ProfileComponent } from './AllComponents/profile/profile.component';

//
// Import the module from the SDK
import { AuthModule } from '@auth0/auth0-angular'; //To configure Auth0 in angular
import { environment as envirn } from 'src/environments/environment'; //To get angular credentials from env gotten from the json file


@NgModule({
  declarations: [
    //Added Modules
    NavBarComponent,
    UserComponent,
    CartComponent,
    ProductsComponent,
    
    //Third Party
    
    //Default Modules
    AppComponent,
     LoginComponent,
     LogoutComponent,
     RegisterComponent,
     AuthButtonsComponent,
     HomeComponent,
     CheckoutComponent,
     ProfileComponent
  ],
  imports: [
    //Default Modules
    BrowserModule,
    AppRoutingModule,
    //Added Modules
    FormsModule,
    HttpClientModule,
    [CommonModule],
    AuthModule.forRoot({
        ...envirn.auth,
        httpInterceptor:{
          allowedList:[
            'https://localhost:7116/Order/ALLPRODUCTRELATIONS',//only the requests that go here will require an authorization token
            // 'https://localhost:7116/Product',
            'https://localhost:7116​/User'
            // 'https://localhost:7116​/UserProfile​/CreateProfile',
            // 'https://localhost:7116/Products/AddProduct',
            // 'https://localhost:7029'
        ]
        }

      }),

  ],
  providers: [
  
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
