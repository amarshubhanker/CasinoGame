import { Component, OnInit } from '@angular/core';
import {UserService} from "../services/user.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  uniqueId: string;
  loading = false;
  loginError = false;
  constructor( private userService: UserService,
               private router: Router) { }

  ngOnInit() {
    this.userService.logout();
  }

  login() {
    this.loading = true;
    this.userService.login(this.uniqueId)
      .subscribe( users => {
        if (users.UserId >= 0) {
          localStorage.setItem('currentUser', users.UserId);
          this.userService.emitUserName(users.UserName);
          this.userService.emitBalance(users.UserBalance);
          this.router.navigate(['roulette']);
        } else {
          this.loginError = true;
          this.loading = false;
        }
        },
        error => {
            console.log(error);
            this.loading = false;
      });
  }
}
