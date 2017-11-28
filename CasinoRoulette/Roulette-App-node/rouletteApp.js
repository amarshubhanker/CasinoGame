const PORT = 3200;
var express = require("express");
var bodyParser = require("body-parser");
var app = express();

var functions = require(__dirname+"/functions.js");


app.use(bodyParser.urlencoded({'extended':'true'}));
app.use(bodyParser.json());
app.use(bodyParser.json({ type: 'application/vnd.api+json' }));
app.use(express.static(__dirname+"/dist"));

// application
app.get('*', function(req, res) {
    res.sendFile(__dirname + '/dist/index.html'); // load the single view file (angular will handle the page changes on the front-end)
});

// login 
app.post('/api/Users', function(req, res) { functions.login(req, res) });

// get the UserDetail from userId (stored in local storage if already logged in)
app.post('/api/Users/getUser', function(req, res) { functions.getUser(req, res) });

// start submit bet to validate and play if validation success
app.post('/api/Bet', function(req, res) { functions.bet(req, res) });

app.listen(PORT, function () {
    console.log('App listening on port ' + PORT);
});
