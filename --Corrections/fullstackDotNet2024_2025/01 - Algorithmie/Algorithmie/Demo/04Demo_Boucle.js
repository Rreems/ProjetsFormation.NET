//Boucle While (tant que)

// let i = 0
// let som = 0

// while(som <= 100){
//     i++ // i = i +1 
//     som += i // som = som + i
     
// }

// alert("La valeur cherchée est N = "+i+ " est la somme vaut : "+som)


// Boucle For (Pour)

// let somme = 0
// let final = 10
// let initial = 1
// let pas = 1
//    // for(let i=1;i<=10;i++)
// for(let i=initial;i<=final;i += pas){// i +=1 / i = i +1
//     somme += i // somme  = somme + i
// } 

// alert("La somme des 10 premiers entiers vaut : "+somme)

// Boucle Do While (faire tant que)

// let input

// do{
//     input = prompt("entrer une valeur entre 1 et 3")
// }while(input<1 || input>3)

// alert("Valeur entrée : "+input)


for(let i = 0; i<5; i++){
    let message = ""
    for(let j = 0; j<=5; j++){
        message += "O"
    }
    message += "X"
    console.log(message)
}


