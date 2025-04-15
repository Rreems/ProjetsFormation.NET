let nbcopies = prompt("Nombre de photocopies :")

// if(nbcopies <10){
//     alert("Le prix seras de "+ nbcopies * 0.5 + " €")
// }else if (nbcopies <= 20){
//     alert("Le prix seras de "+ nbcopies * 0.4 + " €")
// }else{
//     alert("Le prix seras de "+ nbcopies * 0.3 + " €")
// }

let coeff = 0.3

if(nbcopies < 10){
    coeff = 0.5
}else if (nbcopies <= 20){
    coeff = 0.4
}

alert("Le prix seras de "+ nbcopies * coeff + " €")