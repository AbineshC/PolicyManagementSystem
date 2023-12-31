﻿import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { AppComponent } from "./app.component";
import { JwtInterceptor } from "./_helpers/jwt.interceptor";
import { ErrorInterceptor } from "./_helpers/error.interceptor";
import { HomeComponent } from "./home/home.component";
import { AlertComponent } from "./_components/alert.component";
import { AppRoutingModule } from "./app-routing.module";
import { ReactiveFormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { PolicyViewComponent } from './policy-view/policy-view.component';
import { ClaimsAddComponent } from './claims-add/claims-add.component';
import { PolicyformComponent } from './policyform/policyform.component';
import { CreatepolicyComponent } from './createpolicy/createpolicy.component';

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpClientModule,
        AppRoutingModule
    ],
    declarations: [
        AppComponent,
        AlertComponent,
        HomeComponent,
        PolicyViewComponent,
        ClaimsAddComponent,
        PolicyformComponent,
        CreatepolicyComponent
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    ],
    bootstrap: [AppComponent]
})
export class AppModule { };