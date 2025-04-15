let habitant = 96809
let taux = 0.89
let habitantFinal = 120000
let nombreAnnee = 0;

while(habitant<habitantFinal){
    habitant = habitant*(1+taux/100)
    nombreAnnee++
}

alert("La population seras de 120 000 au bout de "+nombreAnnee+" années")