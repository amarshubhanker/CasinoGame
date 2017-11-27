import {Component, OnDestroy, OnInit} from '@angular/core';
import {RouletteService} from '../services/roulette.service';
import {Constants} from './constants';
import {UserService} from '../services/user.service';
import {Subscription} from 'rxjs/Subscription';
import {RandomnumberService} from "../services/randomnumber.service";

@Component({
  selector: 'app-roulette',
  templateUrl: './roulette.component.html',
  styleUrls: ['./roulette.component.css']
})
export class RouletteComponent implements OnInit, OnDestroy {

  betInp: Array<number> = new Array<number>();
  options: Array<string> = new Array<string>();
  totalBet = 0;
  betId: number;
  balance: number;
  balanceSubscription: Subscription;
  isDataRec = false;
  constructor(private rouletteService: RouletteService,
              private userService: UserService) { }

  ngOnInit() {
    this.balance = this.userService.balanceSubject.getValue();
    this.balanceSubscription = this.userService.balanceSubject.subscribe((value) => {
      this.balance = value;
      this.isDataRec = true;
    },
      error => {
        console.log(error);
    });

    Constants.BET_OPTIONS.forEach(op => this.options.push(op.bet));
    for ( let i = 0; i < this.options.length; i++) {
      this.betInp.push(0);
    }
  }

  ngOnDestroy() {
    this.balanceSubscription.unsubscribe();
  }

  isInputDisabled(index) {
    if (!this.betInp[index]) {
      this.betInp[index] = 0;
    }
    if ( this.totalBet > 0 && (this.betInp[index] === 0) ) {
      return true;
    }
    return false;
  }
  computeBet(index) {
    this.totalBet = this.betInp[index];
    this.betId = Constants.BET_OPTIONS[index].id;
  }
  play() {
    // confirmation
    if (confirm('Are you sure you want to place the bet?')) {
        let bet = {
          'userId': localStorage.getItem('currentUser'),
          'betId': this.betId,
          'betAmount': this.totalBet
        };

        this.rouletteService.postBet(bet).subscribe( res => {
          if (res.validationError) {
            alert(res.validationError);
          } else if (res.winAmount) {
            alert('Random number is ' + res.randomNum + '. Congrats! You have won ' + res.winAmount);
            this.userService.emitBalance(res.userBalance);
          } else {
            alert('Random number is ' + res.randomNum + '. Oops! Try again..');
            this.userService.emitBalance(res.userBalance);
          }
        });
    }
  }
}
