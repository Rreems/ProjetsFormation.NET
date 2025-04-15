let ab = prompt("Longueur de AB")
let bc = prompt("Longueur de BC")
let ac = prompt("Longueur de AC")

if(ab == bc){
    if(bc == ac){
        alert("Le triangle est équilatéral")
    }else{
        alert("Le triangle est isocéle en B")
    }
}else if( bc == ac){
    alert("Le triangle est isocéle en C")
}else if(ab == ac){
    alert("Le triangle est isocéle en A")
}else{
    alert("Le triangle est quelconque")
}