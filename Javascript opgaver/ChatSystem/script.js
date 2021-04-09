var latestChatId = 0;

window.onload = function () {
    //Hide the chat before username written
    hideChat();
    //load username into input
    getUsername();
    //Refresh messages every second
    setInterval(getMessages, 10000);
    //make event for when a key is pressed on the textarea (chat input)
    document.getElementById("chatInput").addEventListener("keydown", function (event) {
        if (event.keyCode === 13) {
            //Enter is pressed
            //cancel the enter to make sure no space is made in the text
            event.preventDefault();
            postMessage();
        }
    })
};


function hideChat() {
    $("#chatContainer").hide();
}
function showChat() {
    //Make sure username is not empty
    if ($("#usernameInput").val()) {

        //Save the username entered to storage
        saveUsername();

        //hides the username input and shows the chat
        $("#chatContainer").show("slow");
        $("#usernameDiv").hide();

        //Get messages and then focus on input
        getMessages();
        $("#chatInput").focus();
    }
}

function saveUsername() {
    //find username user has entered
    let user = $("#usernameInput").val();
    localStorage.setItem("username", user)
}
function getUsername() {
    //Get the saved username
    let username = localStorage.getItem("username");
    //make sure username is not empty
    if (username != null) {
        $("#usernameInput").val(username);
    }
}

function getMessages() {
    $.ajax({
        url: "http://chillyskye.dk/api/",
        type: "get",
        dataType: "json",
        data: { "amount": "20" },
        success: function (result) {
            //Display what got returned from the get request
            displayMessages(result);
        }
    });
}
function displayMessages(messages) {
    //Loop messages and add them to textbox
    messages.forEach(element => {

        if (latestChatId < parseInt(element.id)) {
            let text;
            //Convert the unix timestamp
            let d = new Date(element.timestamp * 1000);
            //Could easily use more date info, but this looks cleaner
            let dateText = `kl.${d.getHours()}:${d.getMinutes()}`;

            //stitch together a text
            //If its the user who has posted the message, make it blue to make it easier to find own message
            if (element.name == $("#usernameInput").val()) {
                text = `<div class="item"><div class="chatMessage">${element.message}</div><div class="chatUnder" style="color: blue">${element.name} - ${dateText}</div></div>`;
            }
            else {
                text = `<div class="item"><div class="chatMessage">${element.message}</div><div class="chatUnder">${element.name} - ${dateText}</div></div>`;
            }

            //Put text into the chatbox
            $("#chatDiv").append(text);
            //Save the latest chat id
            latestChatId = element.id;
            //for a new message you should scroll to bottom
            scrollBottom();
        }
    });

}
function postMessage() {
    //find values
    let username = $("#usernameInput").val();
    let message = $("#chatInput").val();
    //Post message
    $.ajax({
        url: "http://chillyskye.dk/api/",
        type: "POST",
        dataType: "json",
        data: { "name": username, "message": message },
        success: function (result) {
            //Check if any errors happened
            if (result.error == true) {
                alert(result.message);
            }
        }
    });
    //Make message input empty
    $("#chatInput").val("");
    //Refresh chat when new message posted
    getMessages();
}

function scrollBottom() {
    //Scroll to bottom
    let e = document.getElementById("chatDiv");
    e.scrollTop = e.scrollHeight;
}
