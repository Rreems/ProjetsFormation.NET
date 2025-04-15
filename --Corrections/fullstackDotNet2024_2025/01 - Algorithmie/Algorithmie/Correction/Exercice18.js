let a = Number(prompt("Valeur 1 :"))
let b = Number(prompt("Valeur 2 :"))

console.log(max(a,b));


function max(valeur1,valeur2){
    let result 
    if(valeur1 > valeur2){
        result = valeur1
    }else{
        result = valeur2
    }

    return result
}


function max2(valeur1,valeur2){
    if(valeur1 > valeur2){
        return valeur1
    }
    return valeur2
}