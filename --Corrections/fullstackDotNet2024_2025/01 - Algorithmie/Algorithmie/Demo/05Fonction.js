procedure()
procedure()
procedure()


function division (a,b){
    let result = 0;
    if(b != 0){
        result = a/b
    }else{
        console.log("Division par 0 impossible");
        return null;
    }
    return result
}


function procedure (){
    console.log("Debut de la procedure")

    let input = getInput("Entrer une valeur")

    let firstNumber = 10
    let secondNumber = 0
    
    let resultat = division(firstNumber,secondNumber)
    console.log(division(15,12));
    console.log(division(10,12));
    console.log(division(15,0));
    console.log(division(1,1));
    console.log(division(15,0));
    console.log(division(0,12));
    
    
    console.log(resultat);
}

function getInput (message){
    return Number(prompt(message))
}