import {Component, OnDestroy, OnInit} from '@angular/core';
import {UserService} from '../services/user.service';
import {Subscription} from "rxjs/Subscription";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit, OnDestroy {

  name: string;
  balance: number;
  nameSubscription: Subscription;
  balanceSubscription: Subscription;

  constructor(private userService: UserService) { }

  ngOnInit() {

    this.name = this.userService.userNameSubject.getValue();
    this.nameSubscription = this.userService.userNameSubject.subscribe(value => {
      this.name = value;
    },
    error => {
      console.log(error);
    });

    this.balance = this.userService.balanceSubject.getValue();
    this.balanceSubscription = this.userService.balanceSubject.subscribe(value => {
      this.balance = value;
    },
      error => {
        console.log(error);
    });
  }

  ngOnDestroy() {
    console.log('in destroy navbar')
    this.balanceSubscription.unsubscribe();
    this.nameSubscription.unsubscribe();
  }

  isLoggedIn() {
    return this.userService.isLoggedIn();
  }
}
