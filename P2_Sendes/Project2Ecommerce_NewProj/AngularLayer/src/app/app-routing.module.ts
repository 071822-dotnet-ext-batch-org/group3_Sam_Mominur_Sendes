import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//Added Features and Pages Routes
import { HomeComponent } from './AllComponents/Home/home/home.component';
// import { NavBarComponent } from './AllComponents/nav-bar/nav-bar.component';
import { ProductsComponent } from './AllComponents/products/products.component';
import { LoginComponent } from './AllComponents/login/login.component';
import { RegisterComponent } from './AllComponents/register/register.component';
import { LogoutComponent } from './AllComponents/logout/logout.component';
import { UserComponent } from './AllComponents/user/user.component';
import { CartComponent } from './AllComponents/cart/cart.component';
import { ProfileComponent } from './AllComponents/profile/profile.component';
import { StoreComponent } from './AllComponents/products/Store/store/store.component';


//Auth0 Imports
import { AuthGuard } from '@auth0/auth0-angular';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { InterceptorService } from './Services/Interceptor/interceptor.service';
import { ProductDetailsComponent } from './AllComponents/products/ProductDetails/product-details/product-details.component';
//---------------------------------------Routing Section----------------------
const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'logout', component: LogoutComponent },
  { path: 'users', component: UserComponent, canActivate: [AuthGuard] },
  { path: 'cart', component: CartComponent },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard]},
  { path: 'store/product', component: ProductsComponent },
  // { path: 'store/product', component: ProductDetailsComponent},
  { path: 'store', component: StoreComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers:[
    // {
      // provide : HTTP_INTERCEPTORS,
      // useClass: InterceptorService,
      // multi: true
    //  }
  ]
})
export class AppRoutingModule { }
