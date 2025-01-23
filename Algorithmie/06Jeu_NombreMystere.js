//   VAR DOM

let firstDiv = document.createElement("firstDiv")

let contenuTitre = "<img src=\"GameSaw.gif\" alt=\"Superbe image\" />"
let contenuParagraphe = "Le jeu va commencer... <br><br> Entrez une valeur entre 1 et 100, pour essayer de deviner le nombre."

let body = document.querySelector("body") ;

// ******************************
// ****   VAR Jeu
let nbResult = Math.floor(Math.random()*99)+1 ;
console.log("Result caché:" + nbResult);

let nbChances = 5 ;


// ///////////////////////////
// ***********  LE DOM ?

firstDiv.innerHTML = `
    <div>
        <h1>${contenuTitre}</h1>
        <p>${contenuParagraphe}</p>
    </div>`
body.appendChild(firstDiv);        


let divParamFct = document.createElement("divParamFct");
body.appendChild(divParamFct);        


let lastDiv = document.createElement("lastDiv")
body.appendChild(lastDiv);        
    

// ****** Champ input
let divInputZone = document.createElement("divInputZone");
divInputZone.innerHTML = `<input type="number" id="inputZone" name="name" required minlength="1" maxlength="2" size="6" /><br>`
divParamFct.appendChild(divInputZone); 
let inputZone = document.getElementById("inputZone");

// ****************
// Bouton Lancement jeu
let divBoutonValider = document.createElement("divBoutonValider");

// divBoutonValider.innerHTML= `
// <button id="boutonValider">Valider</button> `  ;

divBoutonValider.innerHTML= `
    <img src=\"valider.gif\" alt=\"Superbe image valider\" max-width=\"80\" height=\"80\"/>`;

    divParamFct.appendChild(divBoutonValider);

let divTextJeu = document.createElement("divTextJeu");
divTextJeu.innerHTML = "";
divParamFct.appendChild(divTextJeu);



divBoutonValider.addEventListener("click", function(){

    firstDiv.remove() ;
    // document.getElementById("zoneProposition").remove();
    
    console.log("val:" + inputZone.value);

    //  0 -> En cours ; 1-> Defaite ; 2-> Victoire
    let result = tourDeJeu(inputZone.value);
    console.log("Result post-tour:" + result);

    if (result == 1) {
        divParamFct.remove();
    } else if(result == 2) {
        divParamFct.remove();
    }

});




// ************************************
//    Fonction tourDeJeu

function tourDeJeu(nbUser) {
    let result = 0 ;
        //  ********  LE JEU 

    if(nbChances >= 1 && nbUser != nbResult){
        nbChances-- ;

        let msg = "";
        
        switch (true) {
            case nbUser > nbResult:
                msg +=("C - ")
                break;
            case nbUser < nbResult:
                msg +=("C + " )
                break;            
        
            default:
                break;
        }

        if (Math.abs(nbResult - nbUser) >= 30) {
            msg+="<br> Et en plus t'es trèèèès loin !"
        }

        if (Math.abs(nbResult - nbUser) > 15 && Math.abs(nbResult - nbUser) < 30) {
            msg+="<br> Mais bon, tu t'approches !"
        }
        
        if (Math.abs(nbResult - nbUser) <= 15 && Math.abs(nbResult - nbUser) > 5) {
            msg+="<br> T'es assez près"
        }

        
        if (Math.abs(nbResult - nbUser) <= 5  ) {
            msg+="<br> T'es tout près !!!"
        }    
        
        divTextJeu.innerHTML= ("<br>" + msg + "\n" + nbChances + " essais restants.");


        nbUser = inputZone.value ;

    };

    console.log("Post tour, nb Chances: " + nbChances);

    if (nbUser == nbResult) {
        console.log("Bravo, gagné ! " + nbChances + " essais restants");
        result = 2

        lastDiv.innerHTML= `GAGNÉ !!!
        <img src=\"gagneJig.gif\" alt=\"Superbe image valider\" />
        `


    } else if (nbChances < 1) {
        console.log("Nul, perdu...\n C'était " + nbResult);
        result = 2


        lastDiv.innerHTML= `perdu.
        <img src=\"perduJig.gif\" alt=\"Superbe image valider\" />
        `

        //window.location.reload();
        // window.close();
        
    }

    return result ; 
};