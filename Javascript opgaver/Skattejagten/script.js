
var ctx;
var canvas;
var map;
var treasure;

var treasureY;
var treasureX;

var attempts;
var failMargin = 20;

window.onload = function () {
    //Find canvas
    canvas = document.getElementById("canvasMap");
    ctx = canvas.getContext("2d");
    
    newGame();

    //Listen for mouseclick on the canvas
    canvas.addEventListener("mousedown", function (e) {
        getMousePosition(canvas, e);
    });
    //Start a new game.
    
}

function newGame() {
    drawMap();
    let height = canvas.height;
    let width = canvas.width;
    
    treasureY = Math.floor(Math.random() * height);
    treasureX = Math.floor(Math.random() * width);
    attempts = 5;


    // console.log("Kiste på: " + treasureX + "," + treasureY);
}

function checkClick(x, y) {
    if (attempts > 0) {
        //calculate distance from click to treasure
        let treasureYDist = treasureY - y;
        let treasureXDist = treasureX - x;

        // console.log(treasureYDist);
        // console.log(treasureXDist);

        //Checks if the treasure is nearby the click, and makes it easier to hit the chest.
        if (treasureYDist <= failMargin && treasureYDist >= -failMargin && treasureXDist <= failMargin && treasureXDist >= -failMargin) {
            alert("du fandt kisten!");
            winGame();
        }
        else {
            //Tell user if supposed to go up, down, left, rigt
            switch (true) {
                case treasureYDist < 0: console.log("Du skal længere op");
                    break;
                case treasureYDist > 0: console.log("Du skal længere ned");
                    break;
            }
            switch (true) {
                case treasureXDist < 0: console.log("Du skal længere til venstre");
                    break;
                case treasureXDist > 0: console.log("Du skal længere til højre");
                    break;
            }
        }
        attempts--;
        //After attempts is lowered, check if the game is supposed to end
        if (attempts <= 0) {
            console.log("Spillet er ovre, Nyt spil om 15 sekunder...");
            restartGame();
        }
    }

}

function winGame(){
    //confetti
    Showconfetti();
    restartGame();
}

function restartGame(){
    drawTreasure();
    setTimeout(refreshPage, 15000);
}

function refreshPage(){
    location.reload();
}

function drawMap(){
    //Create an image and set the location
    map = new Image();
    map.src = "treasuremap.png";
    map.onload = function () {
        //Clear previous image
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        ctx.drawImage(map, 0, 0);
    }
}
function drawTreasure() {
    //Load treasure to map
    treasure = new Image();
    treasure.src = "redx.png";
    //make treasure invisible
    treasure.onload = function () {
        //place the image at the tresure location
        ctx.drawImage(treasure, treasureX, treasureY, 20, 20);
    }
}

function getMousePosition(canvas, event) {
    let rect = canvas.getBoundingClientRect();
    let x = event.clientX - rect.left;
    let y = event.clientY - rect.top;
    // console.log("Coordinate x: " + x,
    //     "Coordinate y: " + y);
    //Check if the click was at a treasure
    checkClick(x, y);
}

