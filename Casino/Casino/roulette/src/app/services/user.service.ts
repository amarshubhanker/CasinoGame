import {Injectable, OnInit} from '@angular/core';
import {Http, Headers} from "@angular/http";
import "rxjs/add/operator/map";
import {BehaviorSubject} from "rxjs/BehaviorSubject";

// const BASE_URL = 'http://localhost:3000/Users';
const BASE_URL = 'api/Users/';
const header = {headers: new Headers({'Content-Type': 'application/json'})};

@Injectable()
export class UserService implements OnInit {

  userNameSubject = new BehaviorSubject('Guest');
  balanceSubject = new BehaviorSubject(0);

  constructor(private http: Http) { }

  emitUserName(value) {
    this.userNameSubject.next(value);
  }

  emitBalance(value) {
    this.balanceSubject.next(value);
  }

  ngOnInit() {
    this.updateUser();
  }

  updateUser() {
    console.log('in update user');
    if (this.isLoggedIn()) {
      this.getUserById(localStorage.getItem('currentUser'))
        .subscribe(data => {
          if (data.UserId >= 0) {
            this.emitUserName(data.UserName);
            this.emitBalance(data.UserBalance);
          }
        });
    }
  }

  login(uniqueId) {
    let data = {'uniqueId': uniqueId};
    return this.http.post(BASE_URL, data, header)
      .map(res => res.json());
  }

  logout() {
    localStorage.removeItem('currentUser');
  }

  isLoggedIn() {
    if (localStorage.getItem('currentUser')) {
      return true;
    }
    return false;
  }

  getUserById(id) {
    console.log('in getuserbyid');
    console.log(id);
    let data = {'userId': id};
    return this.http.post(BASE_URL + 'getUser', data, header)
      .map(res => res.json());
  }
}
