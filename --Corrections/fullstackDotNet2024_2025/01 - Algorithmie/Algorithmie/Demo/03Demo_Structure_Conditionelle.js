let age = 15

if(age>0){
    if(age>18){
        console.log("M'on utilisateur est bien majeur")
    }else{
        console.log("M'on utilisateur est mineur")
    }
}else{
    console.log("l'age dois etre positif");
}

if(age <10){

}else if(age <15){

}else if( age <18){

}else{

}



switch(age){
    case 15 :
        console.log("L'utilisateur a 15 ans");
        break
    case 17:
        console.log("L'utilisateur a 175 ans");
        break
    case 18:
        console.log("L'utilisateur a 18 ans");
        break
    default:
        break
}