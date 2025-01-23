// ***********************************************************
// ***  Exo boucles imbriquées   - Dedans d'une fonction pour s'amuser

function fctButtonPressed(varEntr) {
    let resultRetour = "" ;

    resultRetour += "VarChamp1: "+ varEntr + "<br>" ;


    let anneeCalculee = 2015 ;
    let nbHabTourcoing = 96809 ;
    let tauxAccr = 0.0089 ; 

    console.log("année : " + anneeCalculee 
        +"\nNb Hab: " + nbHabTourcoing) ;

    while (nbHabTourcoing <= 120000 && anneeCalculee < 50000) {
        anneeCalculee++ ;
        
        nbHabTourcoing += nbHabTourcoing * tauxAccr

        console.log("année : " + anneeCalculee 
            +"\nNb Hab: " + nbHabTourcoing) ;
    }

    resultRetour+=  "Réponse:<br>Ca va atteindre les 120000 en " + anneeCalculee +"."  ;

    return resultRetour;
}


// ***********************************************************
// ***  Tests DOM 

// Création d'un div avec createElement. Dans cette div, on va créer un titre h1 et un paragraphe p
let nouvelleDiv = document.createElement("div")

let contenuTitre = "Reddit 2 - WIP"
let contenuParagraphe = "L'application est en projet tkt"


let monBouton = document.getElementById("boutonValider");

monBouton.addEventListener("click", function () {
    console.log("Vous avez cliqué sur le bouton")

    let baliseChamp1 = document.getElementById("champ1")
    let valueChamp1 = baliseChamp1.value

    let stringResult = fctButtonPressed(valueChamp1);

        



    // On met en page l'affichage
    nouvelleDiv.innerHTML = `
        <div>
            <h1>${contenuTitre}</h1>
            <p>${contenuParagraphe}</p>
            <p>${stringResult}</p>
        </div>
        `;

    // On ajoute la div dans le body
    let body = document.querySelector("body") ;
    body.appendChild(nouvelleDiv);

});

// //   Tracker d'appui touche
// document.addEventListener('keydown', (event) => {
//     console.log("key: " + event.key + "\ntarget: " + event.target + "\n" + "x:"+ event.clientX +" y:"+ event.clientY );
// });