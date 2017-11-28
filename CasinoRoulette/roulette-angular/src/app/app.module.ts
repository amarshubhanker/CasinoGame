import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { LoginComponent } from './login/login.component';
import {FormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
import {HttpModule} from "@angular/http";
import {UserService} from "./services/user.service";
import { RouletteComponent } from './roulette/roulette.component';
import {RouletteService} from "./services/roulette.service";
import {LoginRouteGuard} from "./services/login-route-guard";
import * as $ from 'jquery';
import * as bootstrap from "bootstrap";
import * as bootbox from 'bootbox';

const AppRoutes = [
  {path: '', redirectTo: 'roulette', pathMatch: 'full'},
  {path: 'login', component: LoginComponent},
  {path: 'roulette', component: RouletteComponent, canActivate: [LoginRouteGuard]},
  // otherwise redirect to game
  { path: '**', redirectTo: 'roulette' }
];

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LoginComponent,
    RouletteComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(AppRoutes)
  ],
  providers: [UserService, RouletteService, LoginRouteGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
