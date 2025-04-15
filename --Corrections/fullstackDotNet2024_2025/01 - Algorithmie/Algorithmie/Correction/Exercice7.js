let age = prompt("Veuillez saisir l'age de l'enfant :")

if(age<3 || age >= 18){
    alert("vous ne pouvez pas vous inscrire")
}else{
    if(age <=6){
        alert("- Baby")
    }else if (age <= 8){
        alert("- Poussin")
    }else if (age <= 10){
        alert("- Pupille")
    }else if (age <= 12){
        alert("- Minime")
    }else{
        alert("- Cadet")
    }
}

switch(age){
    case 3,4,5,6 : 
        alert("- Baby")
        break;
    case 7,8 : 
        alert("- Poussin")
        break;
    case 9,10: 
        alert("- Pupille")
        break;
    case 11,12: 
        alert("- minime")
        break;
    case 13,14,15,16,17: 
        alert("- minime")
        break;
    default:
        alert("vous ne pouvez pas vous inscrire")
        break;
}


