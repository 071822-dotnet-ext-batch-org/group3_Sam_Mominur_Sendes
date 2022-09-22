import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './Components/Home/home/home.component';
import { StoreComponent } from './Components/Store/store/store.component';
import { CartComponent } from './Components/Cart/cart/cart.component';
import { LoginComponent } from './Components/Authentication/login/login.component';
import { LogoutComponent } from './Components/Authentication/logout/logout.component';
import { RegisterComponent } from './Components/Authentication/register/register.component';
import { CheckoutComponent } from './Components/Pages/checkout/checkout.component';
import { OrderCompleteComponent } from './Components/Pages/order-complete/order-complete.component';
import { ProductDetailComponent } from './Components/Pages/product-detail/product-detail.component';
import { ViewProductComponent } from './Components/Store/Features/view-product/view-product.component';
import { WishListComponent } from './Components/Store/Features/wish-list/wish-list.component';
import { OrdersComponent } from './Components/Pages/orders/orders.component';
import { SettingsComponent } from './Components/Pages/settings/settings.component';
import { ProfileComponent } from './Components/User/profile/profile.component';
import { ChatroomsComponent } from './Components/Pages/chatrooms/chatrooms.component';
import { ShareProductComponent } from './Components/Store/Features/share-product/share-product.component';
// import { PoliciesComponent } from './Components/Pages/Settings/policies/policies.component';



const routes: Routes = [
  
  //Pages
  
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'chat', component: ChatroomsComponent },
  // { path: 'policies', component: PoliciesComponent },


  
  
  
  //User Account DashBoard
  { path: 'account', component: ProfileComponent },
  { path: 'account/setttings', component: SettingsComponent },


  { path: 'account/orders', component: OrdersComponent },
  
  
  //Authentication
  { path: 'login', component: LoginComponent },
  { path: 'logout', component: LogoutComponent },
  { path: 'register', component: RegisterComponent },
  
  
  
  //Settings
  
  
  //Store and Product Related
  { path: 'store', component: StoreComponent },
  { path: 'store/product', component: ProductDetailComponent },
  { path: 'store/checkout', component: CheckoutComponent },
  { path: 'store/view-cart', component: CartComponent },
  { path: 'store/comeagain', component: OrderCompleteComponent },
  { path: 'store/product/watch', component: ViewProductComponent },
  { path: 'store/product/share', component: ShareProductComponent },
  { path: 'store/wish-list', component: WishListComponent },





  
  






];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
