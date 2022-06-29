import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InputTextComponent } from './input-text/input-text.component';
import { SignupComponent } from './pages/signup/signup.component';
import { CustomerComponent } from './pages/customer/customer.component';
import { PolicyComponent } from './policy/policy.component';
import { ListPolicyComponent } from './list-policy/list-policy.component';
import { CustomerInputComponent } from './pages/customer-input/customer-input.component';
import { CustomerViewComponent } from './pages/customer-view/customer-view.component';

@NgModule({
  declarations: [AppComponent, InputTextComponent, SignupComponent, CustomerComponent, PolicyComponent, ListPolicyComponent, CustomerInputComponent, CustomerViewComponent],
  imports: [CommonModule, BrowserModule, AppRoutingModule, ReactiveFormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
