let capitalDepart = prompt("Entre votre capital")
let taux = prompt("Entrer votre taux")
let capitalFinal = capitalDepart*2
let annee = 0

while(capitalDepart < capitalFinal){
    capitalDepart = capitalDepart*(1+taux/100)
    annee++
}

alert("Votre capital serat doublé au bout de "+annee+" années")