//returns result of game (random number and amount won)
function playGame(betData) {
    var random = Math.floor((Math.random() * 37));
    var bet = getBet(betData.betId);
    var win = getMultiplier(bet, random) * betData.betAmount;
    return {winAmount: win, randomNum: random};
}

function getBet(betId) {
      switch (betId) {
        case 1:
            return {low: 1, high: 12};

        case 2:
            return {low: 13, high: 24};

        case 3:
            return {low: 25, high: 36};

        case 4:
            return {low: 0, high: 0};

        case 5:
            return {low: 1, high: 18};

        case 6:
            return {low: 19, high: 36};

        case 7:
            return {even: true};

        case 8:
            return {odd: true};

      }
    }

function getMultiplier(bet, random) {
    //if bet on even
    if(bet.even)
    {
        if(random%2 === 0)
            return 1.25;
    }
    // if bet on odd
    else if(bet.odd)
    {
        if(random%2 === 1)
            return 1.25;
    }
    //bet on range
    else if (random >= bet.low && random <= bet.high)
    {
        // bet on 0
        if(bet.high - bet.low === 0)
            return 10;
        // bet on 12s
        else if(bet.high - bet.low === 11)
            return 1.5;
        // bet on halves
        else if(bet.high - bet.low === 17)
            return 1.25;
    }
    return 0;
}

module.exports.playGame = playGame;