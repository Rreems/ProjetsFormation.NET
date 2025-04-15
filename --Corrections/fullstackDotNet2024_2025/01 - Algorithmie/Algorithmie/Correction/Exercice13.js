let max = null

for(let i = 1; i<=6;i++){
    let input = Number(prompt("Entrer la valeur n°"+i))
    if(max< input || max == null){
        max = input
    }
}

alert("La valeur la plus grande est : "+max)
