const buttonAchatCoffee = document.querySelector("#achatCoffee");

const ParagQteCoffee = document.querySelector("#qteCoffee");


window.onload = () => {
    document.querySelector("#panierDiv").innerHTML = ""

    let qteCoffee = localStorage.getItem("qteCoffee") ?? 0;
    let qteTea = localStorage.getItem("qteCoffee") ?? 0;
    let qteJuice = localStorage.getItem("qteJuice") ?? 0;

    displayCoffee(qteCoffee);

}






const ModifyCoffee = (mod) => {
    let qteCoffee = localStorage.getItem("qteCoffee");
    console.log("Qte lue:" + qteCoffee);

    switch (true) {
        case !qteCoffee:
            qteCoffee = 1;
            break;
        case mod == "+":
            qteCoffee++;
            break;
        case mod == "-" && qteCoffee > 0:
            qteCoffee--;
            break;
        default:
            qteCoffee = 0;
            break;
    }

    localStorage.setItem("qteCoffee", qteCoffee);

    displayCoffee(qteCoffee);

};

const displayCoffee = (qteCoffee) => {
    let newLi;
    if (!document.getElementById("qteCoffee") && qteCoffee > 0) {
        newLi = document.createElement("li")
    } else {
        newLi = document.getElementById("qteCoffee")
    }

    if (qteCoffee > 0){

        newLi.setAttribute("id", "qteCoffee")
        newLi.textContent = `Coffee: ${qteCoffee}`
        
        
        const buttonP = document.createElement('button');
        buttonP.addEventListener("click", (event) => {
            // console.log("+coffee");
            ModifyCoffee("+");
        });
        buttonP.textContent = "+"
        newLi.appendChild(buttonP);
        
        const buttonM = document.createElement('button');
        buttonM.addEventListener("click", (event) => {
            // console.log("-coffee");
            ModifyCoffee("-");
        });
        buttonM.textContent = "-"
        newLi.appendChild(buttonM);
        
        // newLi.innerHTML += `  <button class="btnMtest" id="PCoffee">+</button>  <button class="btnMtest" id="MCoffee">-</button>`
        
        document.getElementById("panierDiv").appendChild(newLi)
    }

    else {
        console.log(newLi + "Removed");
        if(newLi != null){
            newLi.remove(); 
        }
    }

}




document.querySelector("#achatCoffee").addEventListener("click", (event) => {
    // console.log("+coffee");
    ModifyCoffee("+");
});
