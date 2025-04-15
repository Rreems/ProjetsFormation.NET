let tableau = []

tableau.push(12)
tableau.push(15)
tableau.push(18)

let value = tableau[2]
let taille = tableau.length
for(let i = 0; i < taille; i++){
    console.log(tableau[i])
}


let tableau2d = [[14,12,15],[9,17,15],[13,12,14],[5,8,13]] 

etudiant1 = tableau2d[0]
etudiant1note1 = tableau2d[0][0]

console.log(etudiant1)
console.log(etudiant1note1)

for(let i = 0 ; i<4;i++){
    console.log("Etudiant N°"+(i+1))
    for(let j = 0; j<3 ; j++){
        console.log("Note N°"+(j+1)+" : "+tableau2d[i][j])
    }
}