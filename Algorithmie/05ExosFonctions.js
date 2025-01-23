

function wichIsBigger (){
    
        // Patch à la con
        lstNombre[1] = lstNombre[0] ;
        lstNombre[1].value = 0

    console.log("FonctionBoutton. Nu1: [" + lstNombre[0].value   +  "] - Nu2: [" + lstNombre[1].value +"]");

    let intOne = Number(lstNombre[0].value)
    let intTwo = Number(lstNombre[1].value)

    
        if (intOne > intTwo) {
            let rep =  intOne;
        } else {
            let rep =  intTwo;
        };
    

    divRep.innerHTML = `<br><div>
    Résultat plus grand nombre: ${rep}
    
    </div>` ;
    


};


function fctAddToList() {
    
    lstString= "";
    console.log("Tentative push: " + lstNombre[0].value)  ; 
    

    if( ! isNaN(Number(lstNombre[0].value)) && Number(lstNombre[0].value) != "" ) {

    
        lst.push(lstNombre[0].value);
        console.log("Lst taille: " + lst.length
            + " - Nbr pushé: [" + lstNombre[0].value + "]"
        );

        for (let index = 0; index < lst.length; index++) {
            lstString += "<br>  "+ lst[index]  ;
            
        }
        
        divRep.innerHTML =`<br><div>
        Résultat de ma liste de ${lst.length} éléments: 
            ${lstString}
        
        </div>` 
    }
}


//  **  Executé par l'event listener 
function fctButtonValider() {
    
    fctAddToList()
    
}


// let intPrem = Number(prompt("Nombre 1 stp ?"));
// let intSec = Number(prompt("Nombre 1 stp ?"));
// intTheBigger = wichIsBigger(intPrem, intSec);
// alert("Nombre le plus grand des deux: " + intTheBigger);

// *******  CONST   & VAR
let contenuTitre = "Exo - les super nombres !" ;
let divInputs = ""
let buttonValider = ""

let body = document.querySelector("body") ;

let divEnTeteProg = document.createElement("div")
let divButtonValider = document.createElement("divButtonValider");

let divRep = document.createElement("div")


let lst = []
// *********

body.appendChild(divEnTeteProg);


body.appendChild(divRep);

divEnTeteProg.innerHTML = `
    <div>
        <h1>${contenuTitre}</h1>
        <form id="form1"> 
            <input id="input1" name="champ" class="form-control"
            type="text"
            placeholder="Nombre à ajouter">  `  
            // <input id="input2" name="champ"  class="form-control"
            // type="text"
            // placeholder="Nombre 2">                              
        +`</form>

        <br>

        <button id="boutonValider">Valider</button>

    </div>` ;

let lstNombre = document.querySelectorAll('input[name="champ"]')

divButtonValider = document.getElementById("boutonValider")

divButtonValider.addEventListener("click", function(){
    
       fctButtonValider();
                    
});        

