let notes = []

for(let i = 1; i <=15 ; i++){
    notes.push(Number(prompt("Entre la note n°"+i)))
}

for(let i =0; i<notes.length;i++){
    console.log(notes[i])
}