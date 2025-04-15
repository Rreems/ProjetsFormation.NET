let taille = prompt("Entrer votre taille")
let poids = prompt("Entrer votre poids")

if((poids >= 43 && poids <= 47 && taille>= 145 && taille <= 169)||
(poids>= 48 && poids <= 53 && taille>= 145 && taille <= 166)||
(poids>= 54 && poids <= 59 && taille>= 145 && taille <= 163)||
(poids>= 60 && poids <= 65 && taille>= 145 && taille <= 160)){
    alert("Taille 1")
}else if((poids>= 48 && poids <= 53 && taille>= 169 && taille <= 178)||
(poids>= 54 && poids <= 59 && taille>= 166 && taille <= 175)||
(poids>= 60 && poids <= 65 && taille>= 163 && taille <= 172)||
(poids>= 66 && poids <= 71 && taille>= 160 && taille <= 169)){
    alert("Taille 2")
}else if ((poids>= 54 && poids <= 59 && taille>= 178 && taille <= 183)||
(poids>= 60 && poids <= 65 && taille>= 175 && taille <= 183)||
(poids>= 66 && poids <= 71 && taille>= 172 && taille <= 183)||
(poids>= 72 && poids <= 77 && taille>= 163 && taille <= 183)){
    alert("Taille 3")
}else{
    alert("La taille n'existe pas")
}