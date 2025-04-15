let input = prompt("entrer une valeur entre 1 et 3")

while(input<1 || input>3){
    input = prompt("Entrer une valeur entre 1 et 3")
}

alert("la valeur entré est : "+ input)