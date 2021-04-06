class Instrument{
    name;
    //Removed sound from play and added as a property, for a better solution.
    sound;
    play(){
            let audio = new Audio(this.sound);
            audio.play();
    }
}
class Stringed extends Instrument{
    name = "Stringed";
    numberOfStrings;

    constructor(numberOfStrings){
        super();
        this.numberOfStrings = numberOfStrings;
    }
}

class Harp extends Stringed{
    name = "Harp";
    sound = "Harp.mp3";
    height;
    constructor(numberOfStrings, height){
        super();
        this.numberOfStrings = numberOfStrings;
        this.height = height;
    }
}
class Guitar extends Stringed{
    name = "Guitar";
    sound = "Guitar.mp3";
    material;
    constructor(numberOfStrings, material){
        super();
        this.numberOfStrings = numberOfStrings;
        this.material = material;
    }
}
class Saxophone extends Instrument{
    name = "Saxophone";
    sound = "epic-saxophone.mp3";
    material;
    constructor(material){
        super();
        this.material = material;
    }
}
class Flute extends Instrument{
    name = "Flute";
    sound = "Flute.mp3";
    holes;
    material;
    constructor(holes, material){
        super();
        this.holes = holes;
        this.material = material;
    }

}
var list;

addClasses();

function addClasses() {
    list = [
    new Harp(4,40),
    new Guitar(6,"Wood"),
    new Saxophone("Cobber"),
    new Flute(5,"Wood"),
    new Harp(6,69)
    ];
    //Save the 
    var body = document.body;

    var count = 0;
    list.forEach(element => {
        
    //Find all properties and values in the object
        Object.entries(element).forEach(prop => {
            body.innerHTML += `<header> ${prop[0]}: ${prop[1]} </header>`
        });
        //Add the button with the playsound function and the object
        body.innerHTML +=   `<button onclick="playsound(list[${count}])"> Play</button>`;
        count++;
    });
}
//Play the sound of the object
function playsound(instrument){
    instrument.play();
}