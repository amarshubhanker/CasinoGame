var BASE_URL = "http://localhost:59854/api/Roulette/";
var request = require('request');
var constants = require("./Constants.js");
var game = require("./game.js");

// starting the game if betting validation is true
function startGame(betDetails, res) {
  var bet = {
      betId: betDetails.betId,
      betAmount: betDetails.betAmount
    };
    var gameRes = game.playGame(bet);
    request({
      uri: BASE_URL + "updatebalance",
      method: "POST",
      form: {
          CustomerId: betDetails.userId,
          BetAmount: betDetails.betAmount,
          WinAmount: gameRes.winAmount
        }
      }, function(error, response, body) {
        if(!error) {
          if(response.statusCode === 200) {
            res.send(JSON.stringify({randomNum: gameRes.randomNum,
              winAmount: gameRes.winAmount,
              userBalance: JSON.parse(body).UserBalance}));
          }
          else {
            res.send({error: "Something went wrong."});
          }
    }
    else {
        res.send(error);
    }
  });
};

// check if bet conditions are satisfied
function validateBet(amount, res) {
  if(amount < constants.MINIMUM_BET) {
  res.send(JSON.stringify({validationError: 'Minimum bet is ' + constants.MINIMUM_BET}));
  return false;
  }
  else if (amount % constants.INCREMENT_STEP !== 0) {
    res.send((JSON.stringify({validationError: 'Betting amount should be in multiples of ' + constants.INCREMENT_STEP})));
    return false;
  }
return true;
};

// after user placed bet, validate and start game.
function bet(req, res) {
    // Recieved req to play.
    // Validate bet
    if(validateBet(req.body.betAmount, res)) {
        // Block amount
        request({
            uri: BASE_URL + "block",
            method: "POST",
            form: {
                CustomerId: req.body.userId,
                BlockedAmount: req.body.betAmount
            }
        }, function (error, response, body) {
            // if insufficient funds, send error
            if (!error) {
                if (response.statusCode === 200) {
                    startGame(req.body, res);
                }
                else {
                    res.send({validationError: "Sorry. Not enough balance"});
                }
            } else {
                res.send(error);
            }
        });
    }
};

// get user from userid stored in local storage (if already logged in)
function getUser(req, res) {
    request({
        uri: BASE_URL + "getUser",
        method: "POST",
        form: {
            CustomerId: req.body.userId
        }
    }, function(error, response, body) {
        if(!error) {
            if(response.statusCode === 200)
                res.send(body);
            else res.send({error: "User not found"});
        } else {
            res.send(error);
        }
    });
};


// get user from unique login id (for login)
function login(req, res) {
    request({
        uri: BASE_URL + "login",
        method: "POST",
        form: {
            uniqueId: req.body.uniqueId
        }
    }, function(error, response, body) {
        if(!error) {
            if(response.statusCode === 200)
                res.send(body);
            else res.send({error: "User not found"});
        } else {
            res.send(error);
        }
    });
};

module.exports = {
    // starting the game if betting validation is true
    startGame: startGame,

    // Validate bet conditions
    validateBet: validateBet,

    // checking betting amount before playing
    bet: bet,

    // getting User detail from Login ID
    getUser: getUser,

    //checking user from login ID
    login: login
};