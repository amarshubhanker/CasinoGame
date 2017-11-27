import { Injectable } from '@angular/core';

@Injectable()
export class RandomnumberService {

  constructor() { }
  resMinimumDifference: number;
  getRandomBetween(min, max) {
    return Math.floor(Math.random() * ( max - min + 1 ) + min );
  }

  getRandomRoulette() {
    // Initialize minimum difference greater than max possible difference;
    this.resMinimumDifference = 900;

    let digits: number;
    let numList = new Array<number>();

    // generate 20 random numbers
    for (let i = 0; i < 10; i++) {
      digits = this.getRandomBetween(1, 10);
      let randNum = 0;
      for (let j = 0; j < digits; j++) {
        randNum = 10 * randNum + this.getRandomBetween(1, 9);
      }
      numList.push(randNum);
    }

    // let tempList = [371, 3, 26, ];
    // this.calculateMinimumDifference(tempList);
    // console.log(this.resMinimumDifference);

    this.calculateMinimumDifference(numList);
    return Math.abs(this.resMinimumDifference % 37);
  }

  calculateMinimumDifference(numList) {
    let numTypeList = new Array<number>(); // stores if number of digits are even (store 1) or odd (store -1)
    let numDiffList = new Array<number>(); // stores sum(odd digits) - sum(even digits) for each number separately;
    for (let i = 0; i < numList.length; i++) {
      numTypeList.push(this.getDigits(numList[i]));
      numDiffList.push(this.getDifference(numList[i]));
    }
    // this.permute( numDiffList, numTypeList, 0, numDiffList.length - 1);
    this.permute( numDiffList, numTypeList, numDiffList.length);

  }

  // permute(numDiffList, numTypeList, startIndex, endIndex) {
  //
  //   if (startIndex === endIndex) {
  //     let difference = 0;
  //     let nextSign = 1;
  //     for ( let i = 0; i < numDiffList.length; i++) {
  //       difference = difference + nextSign * numDiffList[i];
  //       nextSign = nextSign * numTypeList[i];
  //     }
  //     if (this.resMinimumDifference > difference) {
  //       this.resMinimumDifference = difference;
  //     }
  //     } else {
  //     for (let i = endIndex; i >= startIndex; i--) {
  //       [numDiffList[endIndex], numDiffList[i]] = [numDiffList[i], numDiffList[endIndex]];
  //       [numTypeList[endIndex], numTypeList[i]] = [numTypeList[i], numTypeList[endIndex]];
  //       this.permute(numDiffList, numTypeList, startIndex, endIndex - 1);
  //       [numDiffList[endIndex], numDiffList[i]] = [numDiffList[i], numDiffList[endIndex]];
  //       [numTypeList[endIndex], numTypeList[i]] = [numTypeList[i], numTypeList[endIndex]];
  //     }
  //   }
  // }

  permute(numDiffList, numTypeList, size) {
    if (size === 1) {
      let difference = 0;
      let nextSign = 1;
      for ( let i = 0; i < numDiffList.length; i++) {
        difference = difference + nextSign * numDiffList[i];
        nextSign = nextSign * numTypeList[i];
      }
      // console.log(difference);
      if (this.resMinimumDifference > difference) {
        this.resMinimumDifference = difference;
      }
      return;
    }
    for (let i = 0; i < size; i++) {
      this.permute(numDiffList, numTypeList, size - 1);

      if ( size % 2 === 0) {
        [numDiffList[0], numDiffList[size - 1]] = [numDiffList[size - 1], numDiffList[0]];
        [numTypeList[0], numTypeList[size - 1]] = [numTypeList[size - 1], numTypeList[0]];
      } else {
        [numDiffList[i], numDiffList[size - 1]] = [numDiffList[size - 1], numDiffList[i]];
        [numTypeList[i], numTypeList[size - 1]] = [numTypeList[size - 1], numTypeList[i]];
      }
    }
  }

  getDigits(num) {
    let count = 0;
    while (num) {
      count++;
      num = Math.floor(num / 10);
    }
    if (count % 2 === 0) {
      return 1;
    } else {
      return -1;
    }
  }

  // Assuming units place as 1st index.
  // Implying units, hundreds, ten-thousands etc. odd digits and tens, thousands, lakhs etc. even digits.
  getDifference(num) {
    let difference = 0;
    let toggle = 1;
    while (num) {
      difference = difference + (toggle * (num % 10));
      toggle = toggle * -1;
      num = Math.floor(num / 10);
    }
    return difference;
  }
}
