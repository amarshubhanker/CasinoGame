const PORT = 3200;
var express = require("express");
var bodyParser = require("body-parser");
var app = express();
var BASE_URL = "http://localhost:59854//api/roulette/getrouletteplayer";
var request = require("request");
var game = require(__dirname+"/game.js");
var funct = require(__dirname+"/functions.js");

const constants = require(__dirname + "/Constants.js");
const util = require("util");
app.use(bodyParser.urlencoded({'extended':'true'}));
app.use(bodyParser.json());
app.use(bodyParser.json({ type: 'application/vnd.api+json' }));
app.use(express.static(__dirname+"/dist"));

// application -------------------------------------------------------------
app.get('*', function(req, res) {
    res.sendFile('./dist/index.html'); // load the single view file (angular will handle the page changes on the front-end)
});

// check if user of particular Id is present
app.post('/api/Users', funct.users(req, res));

// get the UserDetail from userId
app.post('/api/Users/getUser', funct.getUser(req, res));


// start betting after checking the betting criteria
app.post('/api/Bet', funct.bet(req, res));


app.listen(PORT, function () {
    console.log('App listening on port ' + PORT);
});