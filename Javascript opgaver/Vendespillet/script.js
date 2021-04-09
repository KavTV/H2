
var cards = generateCards();
var flipped = 0;
var cardsMatched = [];
//Id of last card flipped
var lastFlipped;
var defaultColor = "#555";
var tries = 0;

window.onload = function () {
    shuffleCards();
    generateCardHtml();
}


function generateCards() {
    //Specefic selected colors 
    var colors = ["#ff0000", "#ff7300", "#ffdd00", "#8cff00", "#00ff48", "#00ffe1", "#00bbff", "#0055ff", "#7700ff", "#c300ff", "#ff00ae", "#ff004c"];
    //Making list with cards
    var cardList = [];
    //Add 2 cards for each color.
    colors.forEach(element => {
        cardList.push(element);
        cardList.push(element);
    });

    // console.log(cardList);
    return cardList;
}

function shuffleCards() {
    //Randomize position in list
    for (let i = cards.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * i)
        const temp = cards[i]
        cards[i] = cards[j]
        cards[j] = temp
    }

    // console.log(cards);
}

function generateCardHtml() {
    var cardArea = document.getElementById("cardArea");

    for (i = 0; i < cards.length; i++) {
        cardArea.innerHTML += `<div onclick="flipCard(${i})" class="square" id="${i}"></div>`;
    }

}

function flipCard(currentCard) {
    //make sure the user doesent flip more than 2 times and doesent select the same card or already matched card.
    if (flipped < 2 && !checkMatched(currentCard) && lastFlipped != currentCard) {
        var card = document.getElementById(currentCard);
        var triesLabel = document.getElementById("labelCounter");
        //show color of card
        card.style.background = cards[currentCard];

        //console.log(lastFlipped);
        //add to counter since we set it to 0 under
        flipped++;
        tries++;
        triesLabel.innerHTML = tries;
        //Check if its the first of the 2 turns
        if (lastFlipped != undefined) {
            console.log(cards[lastFlipped]);
            console.log(cards[currentCard]);

            if (cards[lastFlipped] == cards[currentCard]) {
                console.log("DU FIK ET PAR");
                //Since we got a pair, add them to the list of found pairs
                pair(lastFlipped, currentCard);
            }
            else {
                setTimeout(unflipCards, 2000, lastFlipped, currentCard);
            }
        }
        //If it is fist time in turn picking card, add it to variable.
        else {
            //Remember this card for next turn
            lastFlipped = currentCard;
        }

    }
}

function checkMatched(card1) {

    var count = 0;
    cardsMatched.forEach(element => {
        //If the card is already matched add to counter, since returning to true didnt do anything.
        if (card1 == element) {
            count++;
        }
    });
    //If count = 0 then it has not been matched yet
    if(count == 0){
        return false;
    }
    else{
        return true;
    }
    //if the card is not matched yet, return false
}

function pair(card1, card2) {
    //Add the matched cards to matched list
    cardsMatched.push(card1);
    cardsMatched.push(card2);
    //Reset
    lastFlipped = undefined;
    flipped = 0;
}

function unflipCards(card1, card2) {
    //Fold cards
    var firstCard = document.getElementById(card1);
    var secondCard = document.getElementById(card2);
    //Remove the color of the 2 cards
    firstCard.style.background = defaultColor;
    secondCard.style.background = defaultColor;
    //Forget last card flipped, since we flipped 2
    lastFlipped = undefined;
    //Reset the counter
    flipped = 0;
}