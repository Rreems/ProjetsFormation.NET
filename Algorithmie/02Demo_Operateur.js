/*  -> Prompt de prénoms

let valeurRentree = 0;

console.log(valeurRentree);

var input = prompt("Nom ?") ;

varConcatNomPrenom = input ;

console.log(varConcatNomPrenom);

var input = prompt("Prénom ?") ;

varConcatNomPrenom = input + " " + varConcatNomPrenom

console.log("Tu t'appelles " + varConcatNomPrenom+ Math.pow(4,2));
**************************************************/




/*   -> Input & mise à la puissance en pagaille

var input = prompt("Num à mettre au carré ?") ;
var nombre1 = input;
var nombre1OKR = Math.pow(Number(input),2);

var input = prompt("Num 2 à mettre au carré ?") ;
var nombre2 = Number(input);


console.log(nombre1 + " au carré = " + nombre1OKR 
    +"\n" + nombre2 + " au carré = " + Math.pow(nombre2,2));
console.log("2 au carré = 4" );

//console.log("Ta var au carré:" + Math.pow(Number(prompt("Nombre:")),2) );
*/

/**************************************************************************** */
//   If imbriqué


// let varPromptStr = prompt("Entrez un nombre entier: \n") ;

// let varReel = /*varPromptStr*/ Number(varPromptStr)
// //    alert("fhefh");

// var varAffichee = varReel

// /*
// if ((varReel  % 3) == 0) {
//     console.log(varAffichee + " est divisible par 3." );
// } 
// else {
//     console.log(varAffichee + " n'est pas divisible par 3 !!!" );
// }
//   */  

// console.log("Le réel " + varAffichee+ " " + ((varReel%3) == 0 ? "est" : "n'est pas") + " divisible par 3."     );
// /********************************************************************************* */



// let maVar =  prompt("mot ?");

// if ( maVar.match ){
//     alert("ui")
// }


//  *****************************************************************************
//   EXO 5 - Freestyle photocopies.
// let nbCopies = prompt("Nb copies ?");
// let prix = 0 ;

// if (nbCopies > 0) {
//     //   Moins 10 copies
//     if (nbCopies < 10) {
//         prix = 0.5 * nbCopies ;
        
//     } else {
//         prix += 0.5 * 10

//         // Moins 20 copies
//         if (nbCopies < 20) {
//             prix += (nbCopies -10) * 0.4
            
            
//         // Plus de 20 copies
//         } else {
//             prix +=  10 *0.4  +  (nbCopies -20) *0.3
//         }
//     }    
//     alert ("Vous allez payer: " + prix + " €.")
// }

// /******************************************************************* */
// Exo  calcul

// let nbAnnees = Number(prompt ("Combien d'années ?"));
// let capital = Number(prompt ("Capital de départ ?"));
// let capitalDepart = capital ;
// //let valTaux = (Number(prompt ("Quel taux ?")) / 100);
// let valTaux = (Number(prompt ("Quel taux ?")) );

// console.log("-" + nbAnnees + "-" + capital + "-" + valTaux + ".");

// /// Controle Num
// if (! Number.isInteger(nbAnnees) |  ! Number.isInteger(capital) 
//     |   isNaN(valTaux) )  {

//     alert ("Erreur int")
// }
// else {

//     //console.log(valTaux);
//     capital = Math.floor((capital * Math.pow((1+ valTaux) , nbAnnees))) ;
    
//     //console.log(capital);
    
//     alert("Ton capital de " + capitalDepart + " après " + nbAnnees + "an(s) à un taux de " 
//         +  (valTaux*1)  + " % est de: " + capital + "€.\n"
//         + " Soit un gain de: " + (capital - capitalDepart) + "€." );
//     }

// /******************************************************************* */
// Exo tests        
        
// let ageVal = Number(prompt("Age du marmot ?"))

// switch (true) {
//     case ageVal >=3 && ageVal <=6:
//         alert ("Enfant de type: Baby")  
//         break;

//     case ageVal >=7 && ageVal <=8:
//         alert ("Enfant de type: Poussin")  
//         break;

//     case ageVal >=9 && ageVal <=10:
//         alert ("Enfant de type: pupille")  
//         break;            
//     case ageVal >=11 && ageVal <=12:
//         alert ("Enfant de type: minime")  
//         break;
//     case ageVal >12:
//         alert ("Enfant de type: cadet")  
//         break;
//     case ageVal >18:
//         alert ("Ce n'est plus un enfant...")  
//         break;

//     default:
//         alert("Enfant nul et non accepté.")
//         break;
//}

// ***************************************************************************
/// Exo triangles



// let coteAB= Number(prompt("Longueur AB ?"));
// let coteBC= Number(prompt("Longueur BC ?"));
// let coteCA= Number(prompt("Longueur CA ?"));

// if (coteAB == coteBC){
//     if (coteAB == coteCA){
//         alert("triangle équilatéral");
//     } else{
//         alert("triangle isocèle en B, et n'est pas équilatéral");
//     }
// } else if (coteAB == coteCA) {
//     alert("triangle isocèle en A, et n'est pas équilatéral");

// } else if(coteBC == coteCA){
//     alert("triangle isocèle en C, et n'est pas équilatéral");
// } else{
//     alert("Triangle assez commun, bof")
// }

// ***********************************************************
/*
let taille= Number(prompt("Taille ?"));
let poids= Number(prompt("Poids ?"));

console.log("taille: " + taille);
console.log("poids: " + poids);

let tailleVetement = 0 ;


switch (true) {
//  Limite du tableau
    case taille < 145 ||taille > 193
        || poids < 43 || poids > 77 :
            
        alert("Taille HS");
        break;
 // Zone taille 1
    case taille <= 160 && poids <= 66:
    case taille <= 169 && poids <= 47:
    case taille <= 166 && poids <= 53:
    case taille <= 163 && poids <= 59:

        alert("Taille 1");
        break;

// Zone taille 2
    case (taille >= 160 && taille <=169) && (poids >=66 && poids <= 71): 
    case (taille >= 163 && taille <=172) && (poids >=60 && poids <= 65):
    case (taille >= 166 && taille <=175) && (poids >=54 && poids <= 59):
    case (taille >= 169 && taille <=178) && (poids >=48 && poids <= 53):        
        alert("Taille 2");
        break;

// Zone taille 3
    case (taille >= 178 && taille <=183) && (poids >=54 && poids <= 77):        
    case (taille == 175) && (poids >=60 && poids <= 77):        
    case (taille == 172) && (poids >=66 && poids <= 77):  
    case (taille >= 163 && taille <=169) && (poids >=72 && poids <= 77):        
        alert("Taille 3");
        break;

    default:
        alert("Taille HS");
        break;
}
*/
// ***********************************************************
// ***  Exos boucles

// let nbFleursDansMonJardinInfiniOuCaPousseVite = Number(prompt ("Fleurs de départ ?"));
// let nbAnnees = 0
// let valTaux = (Number(prompt ("Quel taux ?")) / 100);
// let capitaDepart = nbFleursDansMonJardinInfiniOuCaPousseVite ;

// while (nbFleursDansMonJardinInfiniOuCaPousseVite <= capitaDepart*2  
//     // Petite sécurité contre les boucles infinies
//         && nbAnnees<5000) {
    
//     nbFleursDansMonJardinInfiniOuCaPousseVite
//     = (nbFleursDansMonJardinInfiniOuCaPousseVite  * (1+ valTaux)).toFixed(2) ;
//     nbAnnees++ ;
//     console.log("Année n°" + nbAnnees + ", y'a " 
//      + nbFleursDansMonJardinInfiniOuCaPousseVite
//      + " fleurs dans le jardin. COOL.");
//     }


// alert("Le capital de départ est doublé après " + nbAnnees 
//     + " année(s). Y'a maintenant " 
//     + Number(nbFleursDansMonJardinInfiniOuCaPousseVite).toFixed(0)
//     + " fleurs dans mon jardin infini ou ça pousse vite" 
//     + "(pas de compte en banque, je précise)");

    
// ***********************************************************
// ***  Exo boucle FOR   / DO WHILE

// let valMax = null ;

// for (let index = 1; index <= 6; index++) {
//     let valUser = prompt("Valeur n°" + index+ ", stp:")

//     console.log(`Tour boucle ${index}, nb user: ${valUser}.`
//                   + `Val max: ${valMax}`);

//     if (valMax < valUser  || valMax == null) {
//         valMax = valUser ;
//     }
// }
// alert("Val la plus grande: " + valMax);
// *********************************************************
// let varMulti ;// = Number(prompt("Quelle table tu veux mon pote ?"))

// let tableMult = "" ;


// for (let i = 1; i <= 10; i++) {
//     varMulti = i
//     console.log(`Table de ${varMulti}:`);
//     tableMult += `<br>Table de ${varMulti}:<br>`


//     for (let index = 1; index <= 10; index++) {
        
//         tableMult += `${varMulti} x ${index} = ` + index*varMulti + "<br>" ;
//         //console.log(`${varMulti} x ${index} = ` + index*varMulti);
        
//     }
// }
// ***********************************************************
// ***  Exo 14 - Boucles encore

// let stringResult = "Exo 14, résult de somme:<br>" ;
// let varExpo = Number(prompt("Quelle nombre tu veux mon pote ?"));
// let varTotal = 0 ;

// for (let index = 1; index <= varExpo; index++) {
//     varTotal += index

//     console.log("Var total: " + varTotal + " - index: " + index);
//     stringResult += " +" + index  ;
// }
// stringResult += " = " + varTotal  ;


// ***********************************************************
// ***  Exo boucles imbriquées   - Dedans d'une fonction pour s'amuser

// function fctButtonPressed(varEntr) {
//     let resultRetour = "" ;

//     resultRetour += "VarChamp1: "+ varEntr + "<br>" ;

//     resultRetour+=  tableMult ;

//     return resultRetour;
// }


// ***********************************************************
// ***  Tests DOM 

// Création d'un div avec createElement. Dans cette div, on va créer un titre h1 et un paragraphe p
// let nouvelleDiv = document.createElement("div")

// let contenuTitre = "Reddit 2 - WIP"
// let contenuParagraphe = "L'application est en projet tkt"


// let monBouton = document.getElementById("boutonValider");

// monBouton.addEventListener("click", function () {
//     console.log("Vous avez cliqué sur le bouton")

//     let baliseChamp1 = document.getElementById("champ1")
//     let valueChamp1 = baliseChamp1.value

//     let stringResult = fctButtonPressed(valueChamp1);

        



//     // On met en page l'affichage
//     nouvelleDiv.innerHTML = `
//         <div>
//             <h1>${contenuTitre}</h1>
//             <p>${contenuParagraphe}</p>
//             <p>${stringResult}</p>
//         </div>
//         `;

//     // On ajoute la div dans le body
//     let body = document.querySelector("body") ;
//     body.appendChild(nouvelleDiv);

// });

// //   Tracker d'appui touche
// document.addEventListener('keydown', (event) => {
//     console.log("key: " + event.key + "\ntarget: " + event.target + "\n" + "x:"+ event.clientX +" y:"+ event.clientY );
// });


// *********************************************
//   Exo 16 - Boucle notes de la classe
let lstNotes = [] ;

for (let i = 0; i < 5; i++) {
    lstNotes[i] = Number(prompt("Notes n°" +(i+1)+ " svp."))
}

let choixUser = Number(prompt("Choix menu:"
    +"\n1 - Plus petite note"
    +"\n2 - Plus grande note"
    +"\n3 - Moyenne des notes"
));

    console.log(" :" + lstNotes);

    let noteActu = 0 ;
    let noteMin = 20; 
    let noteMax = 0;
    let totNote = 0;


switch (choixUser) {
    // Plus petite note
    case 1:
        lstNotes.forEach(function (itemNote , noteActu){
            console.log(itemNote +" - "+ noteActu);
            if (itemNote < noteMin){
                noteMin = itemNote
            }
        });
        alert("Note min: " + noteMin)
        break;

    // Plus grande note
    case 2:
        lstNotes.forEach(function (itemNote , noteActu){
            console.log(itemNote +" - "+ noteActu);
            if (itemNote > noteMax){
                noteMax = itemNote
            }
        });
        alert("note Max: " + noteMax)
        break;

    // Moyenne note
    case 3:
        lstNotes.forEach(function (itemNote , noteActu){
            console.log(itemNote +" - "+ noteActu);
            totNote+= itemNote
        });
        
        alert("Moyenne: " + totNote/5)
         break;  


    default:
        alert("Choix menu invalide")
        break;
}