// **** Création d'object JS :o !!
    // class Inv {
    // constructor(nom, qte, prix) {
    //     this.nom = nom;
    //     this.qte = qte;
    //     this.prix = prix;
    //     }
    // }   
    //   let thisInv = new Inv("Boule", 40, 2);
    //   console.log(thisInv);


// ***********************************************************
// ***  Format & initialisation Inventaire

let inventaire = [
    new Map([
        [ "nom", "Boules de Noel" ],
        [ "quantite", 50 ],
        [ "prix", 1.5 ]  ])
        ,
    new Map([
        [ "nom", "Guirlandes" ],
        [ "quantite", 30 ],
        [ "prix", 3.0 ]  ])        
        ,
    new Map([
        [ "nom", "Sapin de Noel" ],
        [ "quantite", 10 ],
        [ "prix", 25.0 ]  ])          

        ,
    new Map([
        [ "nom", "r" ],
        [ "quantite", 200 ],
        [ "prix", 1 ]  ])            

    ] ;


// ***  Variable mal rangées
let indiceTrv = -1 ;    

// ***********************************************************
// ***  Tests accès DOM 
// RANGER LE DOM BORDEL:
    // // On met en page l'affichage
    // firstDiv.innerHTML = `
    //     <div>
    //         <h1>${contenuTitre}</h1>
    //         <p>${contenuParagraphe}</p>
    //         <p>${stringResult}</p>
    //     </div>



// Création d'un div avec createElement. Dans cette div, on va créer un titre h1 et un paragraphe p
let firstDiv = document.createElement("firstDiv")

let contenuTitre = "<img src=\"Inventaire-King-Jouet.gif\" alt=\"Superbe image\" />"
let contenuParagraphe = "L'application est en projet tkt"

let body = document.querySelector("body") ;





//     GESTION ASYNCHRONE pour mot aléatoire 
let motAlea = "t";

let testMot =   fetch("https://trouve-mot.fr/api/random")
        .then((response) => response.json())
        .then((words) => {return words[0].name});

        
    const printAddress = async () => {
        const a = await testMot;
        motAlea = a ;
        console.log(a+ "-a");

        let baliseChampMot = document.getElementById("zoneProposition")
        baliseChampMot.innerText = "Aujourd'hui, pensez au mot : " + a ;
        
        return a ;
    };
    printAddress();
    
//  ******************************


    firstDiv.innerHTML = `
        <div>
            <h1>${contenuTitre}</h1>
            <p>${contenuParagraphe}</p>
        </div>`
    body.appendChild(firstDiv);        
    
        
    let divParamFct = document.createElement("divParamFct");
//divParamFct.innerHTML= "rien de spécial.";


let paragLstInv = document.createElement("paragLstInv");
paragLstInv.innerHTML= "<p>Liste vide</P>";

//*************************************** */
//    Contenu - boutons
//*************************************** */


// ****************
// Bouton Afficher liste
let divBoutonAfficher = document.createElement("divBoutonAfficher");

// divBoutonAfficher.innerHTML= `
// <button id="boutonAfficher">Afficher inventaire</button> `  ;

divBoutonAfficher.innerHTML= `
    <img src=\"Afficher.gif\" alt=\"Superbe image\" max-width=\"80\" height=\"80\"/>`;

body.appendChild(divBoutonAfficher);


divBoutonAfficher.addEventListener("click", function(){
    paragLstInv.innerHTML=
            fctButtonPressedAfficher();

                    
});

// ****************
// Bouton Ajouter
let divBoutonAdd = document.createElement("divBoutonAdd")

// divBoutonAdd.innerHTML= `
// <button id="boutonAdd">Ajout à l'inventaire</button> `  ;
divBoutonAdd.innerHTML= `
    <img src=\"Ajouter.gif\" alt=\"Superbe image\"  max-width=\"80\" height=\"80\"/>
` ;

body.appendChild(divBoutonAdd);

divBoutonAdd.addEventListener("click", function(){
    
    fctButtonPressedAdd();

    paragLstInv.innerHTML= "<br> Element ajouté !<br>" + fctButtonPressedAfficher();

});

// ****************
// Bouton Search
let divBoutonSearch = document.createElement("divBoutonSearch")

// divBoutonSearch.innerHTML= `
// <button id="boutonSearch">Rechercher inventaire</button> `  ;
divBoutonSearch.innerHTML= `
    <img src=\"Rechercher.gif\" alt=\"Superbe image\"  max-width=\"100\" height=\"100\"/>
` ;

body.appendChild(divBoutonSearch);

divBoutonSearch.addEventListener("click", function(){


    
    // let baliseChamp1 = document.getElementById("champ1")
    // let valueChamp1 = baliseChamp1.value



    paragLstInv.innerHTML=
            fctButtonPressedSearch("rechercher");


});

// ****************
// Bouton Supprimer
let divBoutonDelete = document.createElement("divBoutonDelete")

divBoutonDelete.innerHTML= `
<button id="boutonDelete">Delete </button> `  ;
// divBoutonSearch.innerHTML= `
//     <img src=\"Delete.gif\" alt=\"Superbe image\"  max-width=\"100\" height=\"100\"/>
// ` ;

body.appendChild(divBoutonDelete);

divBoutonDelete.addEventListener("click", function(){


    
    // let baliseChamp1 = document.getElementById("champ1")
    // let valueChamp1 = baliseChamp1.value



    paragLstInv.innerHTML=
            fctButtonPressedDelete();


});

// ****************
// Bouton Modif Quantité
let divBoutonModifQte = document.createElement("divBoutonModifQte")

divBoutonModifQte.innerHTML= `
<button id="divBoutonModifQte">Modifier quantité</button> `  ;
// divBoutonSearch.innerHTML= `
//     <img src=\"Delete.gif\" alt=\"Superbe image\"  max-width=\"100\" height=\"100\"/>
// ` ;

body.appendChild(divBoutonModifQte);

divBoutonModifQte.addEventListener("click", function(){


    paragLstInv.innerHTML=
            fctButtonPressedModifQte();


});

// ****************
// Bouton Valeur Totale
let divBoutonTotalValue = document.createElement("divBoutonTotalValue")

divBoutonTotalValue.innerHTML= `
<button id="divBoutonTotalValue">Valeur totale de l'inv </button> `  ;
// divBoutonSearch.innerHTML= `
//     <img src=\"Delete.gif\" alt=\"Superbe image\"  max-width=\"100\" height=\"100\"/>
// ` ;

body.appendChild(divBoutonTotalValue);

divBoutonTotalValue.addEventListener("click", function(){


    
    // let baliseChamp1 = document.getElementById("champ1")
    // let valueChamp1 = baliseChamp1.value



    paragLstInv.innerHTML=
            fctButtonPressedTotalValue();


});




/*
    Objectif programme: 
    v Afficher l’inventaire.
    v Ajouter un produit.
    v Supprimer un produit.
    v Modifier la quantité d’un produit.
    v Rechercher un produit.
    v Calculer la valeur totale de l’inventaire.
    "v" Quitter le programme.

    */

// *******************************************
// **** SUITE ACCES AU DOM
body.appendChild(paragLstInv);

body.appendChild(divParamFct);


// //   Tracker d'appui touche
// document.addEventListener('keydown', (event) => {
//     console.log("key: " + event.key + "\ntarget: " + event.target + "\n" + "x:"+ event.clientX +" y:"+ event.clientY );
// });



// ***********************************************************
// ***  fonction bouton  AFFICHER

// **************************************************
// **
function fctButtonPressedAfficher(varEntr) {
    let resultRetour = "" ;
    //alert("Appel Fct Afficher");
    console.log("Appel Fct Afficher");
    
    resultRetour= `<p>Fct afficher <br>Liste: </p>` ;
    
    for (let i = 0; i < inventaire.length; i++) {
        inventaire[i].forEach((values, keys) => {
            
            resultRetour+= "<br>- " + keys + " :  " + values ;
            // console.log(values, keys)
            
        })
        resultRetour+="<br>"
    };  
    resultRetour+= "</p>" ;
    
    return resultRetour;
}


// ***********************************************************
// ***  fonction trouver Item
// **************************************************
// **
function fctFindItem(varEntr) {
    let resultRetour = "" ;
    let elemRech = varEntr ;
    let elemTrouveBool = false;    


    for (let i = 0; i < inventaire.length; i++) {
        inventaire[i].forEach((values, keys) => {

            // resultRetour+= "<br>- " + keys + " :  " + values ;
            // console.log(values, keys)
            if (values == elemRech && keys == "nom") {                    
                elemTrouveBool = true;
                indiceTrv = i ;
            }

        })

    };


    return [elemTrouveBool , indiceTrv];
};  


// ***********************************************************
// ***  fonction bouton  RECHERCHER / SEARCH
// **************************************************
// **
function fctButtonPressedSearch(varEntr) {
    let resultRetour = "" ;
    //alert("Appel Fct Search");
    console.log("Appel Fct Search");
    
    resultRetour= `<p>Fct Recherche </p>` ;

    let elemRech = prompt("Quel article est à " + varEntr + " ? ");
    let elemTrouveBool = false;


    for (let i = 0; i < inventaire.length; i++) {
        inventaire[i].forEach((values, keys) => {

            // resultRetour+= "<br>- " + keys + " :  " + values ;
            // console.log(values, keys)
            if (values == elemRech && keys == "nom") {
                resultRetour+= "Element trouvé: <br>- nom : " + values ;
                resultRetour+= `<br>- quantité :  ${inventaire[i].get("quantite")} 
                                <br>- prix : ${inventaire[i].get("prix")} ` ;
                    
                elemTrouveBool = true;
                indiceTrv = i ;
            }

        })
        resultRetour+="<br>"
    };  

    if ( ! elemTrouveBool) {
        resultRetour+=`Element non trouvé  :/ `
    }

    console.log("elem trouvé ? " + elemTrouveBool + "\n Indice: " + indiceTrv );

    return [resultRetour, elemTrouveBool , indiceTrv, elemRech];
};


// ***********************************************************
// ***  fonction bouton  AJOUT / ADD
// **************************************************
// **
function fctButtonPressedAdd(varEntr) {
    console.log("Appel Fct Ajout");

    let nomRech = prompt ("Quel est le nom de l'article à ajouter ?")

    let resultRech = fctFindItem(nomRech) ;   // return [elemTrouveBool , indiceTrv];
    console.log("Result Rech: " + resultRech);

    if (resultRech[0]) {
        // Trouvé: ajout aux existants 
        let nbItemActuel = inventaire[resultRech[1]].get("quantite") ;
        console.log("nbItemActuel:" + nbItemActuel);      

        let nbToAdd = Number(prompt ("Article déjà en table. Combien en ajouter ?"));
        
        inventaire[resultRech[1]].set("quantite" , nbItemActuel + nbToAdd);
        console.log("Nb après modif: " + inventaire[resultRech[1]].get("quantite"));      


    } else {
        let nomToAdd = nomRech ;
        let qttToAdd = Number(prompt ("Nouvel article. Quelle quantité en ajouter ?"));
        let prixToAdd = Number(prompt ("Quel prix lui fixer ?"));

        inventaire.push(
            new Map([
                [ "nom", nomToAdd ],
                [ "quantite", qttToAdd ],
                [ "prix", prixToAdd ]  ])           

        );
        
    }
};



// ***********************************************************
// ***  fonction bouton  SUPPRIMER

// **************************************************
function fctButtonPressedDelete(varEntr) {
    console.log("Appel Fct Supprimer");

    let nomRech = prompt ("Quel est le nom de l'article à supprimer ?")


    let resultRech = fctFindItem(nomRech) ; 

    if (resultRech[0]) {
        // Trouvé: ajout aux existants 
        
        inventaire.splice(resultRech[1] , 1 );

        return ("<br><br><div>Article supprimé.</div>"  +
                fctButtonPressedAfficher()) ;

     // Sinon: message d'erreur   
    } else {
        alert("Article non existant de base.")
        return "<br><br><div>"   + fctButtonPressedAfficher() ;

    };
};

// ***********************************************************
// ***  fonction bouton  VALEUR TOTALE

// **************************************************
function fctButtonPressedTotalValue(varEntr) {
    console.log("Appel Fct Valeur Total");

    let valeurTot = 0 ;

    for (let i = 0; i < inventaire.length; i++) {
        inventaire[i].forEach((values, keys) => {

            // resultRetour+= "<br>- " + keys + " :  " + values ;
            // console.log(values, keys)
            if (keys == "prix") {
                valeurArt = values ;
            }
            if (keys == "quantite") {
                qttArt = values ;
            }

        })
        valeurTot += valeurArt * qttArt ;
        console.log("valeur en cours de listing: " + valeurTot);
    };  

    return "<br><br><div>Valeur totale: "   + valeurTot + " €.</div>" 
};



// ***********************************************************
// ***  fonction bouton  MODIFIER QUANTITE

// **************************************************
function fctButtonPressedModifQte (varEntr) {
    console.log("Appel Fct Modif Qte");

    let nomRech = prompt ("Quel est le nom de l'article à modifier ?")


    let resultRech = fctFindItem(nomRech) ; 

    if (resultRech[0]) {
        // Trouvé: modif qté 
        let nouveauNb = prompt ("Quelle quantité affecter ?")        

        inventaire[resultRech[1]].set("quantite" , nouveauNb);

        return ("<br><br><div>Article modifié.</div>"  +
                fctButtonPressedAfficher()) ;

     // Sinon: message d'erreur   
    } else {
        alert("Article non existant de base.")
        return "<br><br><div>"   + fctButtonPressedAfficher() ;

    };
};