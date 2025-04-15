let capital = prompt("Entrer votre capital :")
let taux = 4
let annee = 5

let capitalTotal = capital * Math.pow((1+(taux/100)),annee)
let gain = capitalTotal - capital

 alert("Le capital a apres "+annee+" année a un taux de "+taux+"% est de "+capitalTotal+" € soit un gain de "+gain+" €")