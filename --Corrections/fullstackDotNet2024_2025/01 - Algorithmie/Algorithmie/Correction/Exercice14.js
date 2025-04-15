let input = Number(prompt("Entrer un nombre entier :"))
let somme = 0
let message = ""

for(let i = 1 ; i<=input; i++){
    somme += i // somme = somme + i*
    message += i + "+"
}

message += "="+somme
alert(message)
// alert("la somme est : "+somme)