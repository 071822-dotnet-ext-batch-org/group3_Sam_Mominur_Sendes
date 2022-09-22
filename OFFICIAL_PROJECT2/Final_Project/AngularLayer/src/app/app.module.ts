import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './Components/Home/home/home.component';
import { StoreComponent } from './Components/Store/store/store.component';
import { CartComponent } from './Components/Cart/cart/cart.component';
import { LoginComponent } from './Components/Authentication/login/login.component';
import { RegisterComponent } from './Components/Authentication/register/register.component';
import { LogoutComponent } from './Components/Authentication/logout/logout.component';
import { ProfileComponent } from './Components/User/profile/profile.component';
import { ViewProductComponent } from './Components/Store/Features/view-product/view-product.component';
import { WishListComponent } from './Components/Store/Features/wish-list/wish-list.component';
import { NavComponent } from './Components/nav/nav.component';
import { UIDESIGNComponent } from './Components/UIDESIGN/uidesign/uidesign.component';
import { DashBoardComponent } from './Components/UIDESIGN/dash-board/dash-board.component';
import { CheckoutComponent } from './Components/Pages/checkout/checkout.component';
import { OrderCompleteComponent } from './Components/Pages/order-complete/order-complete.component';
import { ProductDetailComponent } from './Components/Pages/product-detail/product-detail.component';
import { OrdersComponent } from './Components/Pages/orders/orders.component';
import { SettingsComponent } from './Components/Pages/settings/settings.component';
// import { AcountSettingsComponent } from './Components/Pages/Settings/acount-settings/acount-settings.component';
// import { DashSettingsComponent } from './Components/Pages/Settings/dash-settings/dash-settings.component';
// import { PoliciesComponent } from './Components/Pages/Settings/policies/policies.component';
import { ChatroomsComponent } from './Components/Pages/chatrooms/chatrooms.component';
import { MakeProductComponent } from './Components/Pages/make-product/make-product.component';
// import { ProductSettingsComponent } from './Components/Pages/Settings/product-settings/product-settings.component';
import { ShareProductComponent } from './Components/Store/Features/share-product/share-product.component';
import { ProductsComponent } from './Components/Store/StoreProducts/products/products.component';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    StoreComponent,
    CartComponent,
    LoginComponent,
    RegisterComponent,
    LogoutComponent,
    ProfileComponent,
    ViewProductComponent,
    WishListComponent,
    NavComponent,
    UIDESIGNComponent,
    DashBoardComponent,
    CheckoutComponent,
    OrderCompleteComponent,
    ProductDetailComponent,
    OrdersComponent,
    SettingsComponent,
    // AcountSettingsComponent,
    // DashSettingsComponent,
    // PoliciesComponent,
    ChatroomsComponent,
    MakeProductComponent,
    // ProductSettingsComponent,
    ShareProductComponent,
    ProductsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
