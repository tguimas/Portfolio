function validateForm() {
    let name = document.forms["contact"]["name"].value;
    let address = document.forms["contact"]["address"].value;
    let phone = document.forms["contact"]["phone"].value;
    let email = document.forms["contact"]["email"].value;
    let country = document.forms["contact"]["country"].value;
    let message = document.forms["contact"]["message"].value;


    console.log(name);
    console.log(address);
    console.log(email);
    console.log(phone);
    console.log(country);
    console.log(message);

    alert("Submitted!")
    return false
}

function playAudio() {
    const audioElement = document.querySelector('audio');
    audioElement.play();
}

setInterval(() => {
    const now = new Date();
    const hours = now.getHours();
    const minutes = now.getMinutes();
    const seconds = now.getSeconds();

    const formattedTime = `${hours}:${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`;
    document.getElementById('time').innerHTML = formattedTime;
}, 1000);

const clients = new Array("John Smith", "Mary Thompson", "Paul Thompson", "Carl Johnson", "Clara Cox", "Tom Depp");

function clientExists(client) {
    return clients.includes(client);
}

function validate() {
    var clientname = document.getElementById("clientname").value;
    document.getElementById("result").innerText = clientExists(clientname) ? "Yes" : "No";
}

function appendToDisplay(value) {
    document.getElementById('display').value += value;
}

function clearDisplay() {
    document.getElementById('display').value = '';
}

function calculate() {
    const expression = document.getElementById('display').value;
    const result = eval(expression);

    if (result !== undefined) {
        document.getElementById('display').value = result;
    } else {
        document.getElementById('display').value = 'Error';
    }
}
