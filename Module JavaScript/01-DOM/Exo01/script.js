

const reponse = document.querySelector(".reponse");
const nombreSolution = document.querySelector(".nombreSolution");
const result = document.querySelector(".result");
// const nbEssai = document.querySelector(".nbEssai");

let nombreMystere;

let nbEssai = 4;

let gameWin = false;
let gameLost = false;



window.onload = function () {
    ResetGame();
}

function ResetGame() {
    nombreMystere = Math.round(Math.random() * 19 + 1);
    nbEssai = 4;
    gameWin = false;
    gameLost = false;
    // nombreSolution.innerHTML = `<h8>(La solution est ${nombreMystere})</h8>`
    console.log(`La solution est: ${nombreMystere}`);

    result.innerHTML = `<h2>Il vous reste ${nbEssai} essai(s).</h2>`;

}

document.addEventListener("keydown", (event) => {
    message = document.querySelector(".inputText")

    if (event.key == "Enter") {
        validerReponse();
    }
})




function validerReponse() {

    if (reponse.value != nombreMystere
        && nbEssai > 0
        && gameWin == false
        && gameLost == false) {

        nbEssai--;

        result.innerHTML = `<h1>Votre réponse était ${reponse.value} </h1>`
            + `<h2>Il vous reste ${nbEssai} essai(s).</h2>`
            + `Le nombre mystère est ` + (reponse.value < nombreMystere ? "plus grand." : "plus petit.");
    }
    else if (reponse.value == nombreMystere) {
        result.innerHTML = "<h1> VICTOIRE BG.</h1>"
            + "</br><img src=\"https://media1.tenor.com/m/p1Ebl9SlRpwAAAAd/dancing-cat-cat.gif\" width=\"250\" height=\"300\"></img>"
    }

    if (nbEssai <= 0) {
        gameLost = false;
        gameWin = false;

        result.innerHTML = "<h1> DEFAITE.</h1>"
            + "</br><img src=\"https://media1.tenor.com/m/ZyqhFIPi2OgAAAAC/cat-crying-cat.gif\" width=\"400\" height=\"300\"></img>"
    }
}

