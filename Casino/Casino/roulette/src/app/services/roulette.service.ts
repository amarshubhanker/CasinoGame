import { Injectable } from '@angular/core';
// import {RandomnumberService} from "./randomnumber.service";
import {Http} from '@angular/http';
import 'rxjs/add/operator/map';

// const BASE_URL = 'http://localhost:3200/';
const BASE_URL = 'api/Bet/';
const header = new Headers({'Content-Type': 'application/json'});

interface Bet {
  amount?: number;
  low?: number;
  high?: number;
  even?: boolean;
  odd?: boolean;
}

@Injectable()
export class RouletteService {

  constructor(private http: Http) {
  }

  postBet(data) {
    return this.http.post(BASE_URL, data, header)
      .map(res => res.json());
  }
}
