
const result1 = document.querySelector(".result1");
const result2 = document.querySelector(".result2");

const touches = [...document.querySelectorAll(".bouton")];
const listDataKey = touches.map((button) => button.dataset.key) ;

touches.forEach((button) => {
    button.addEventListener("click", (event) => {
        console.log(event.target.dataset.key);
        buttonActived(event.target.dataset.key);
    })
});

// document.querySelectorAll(".bouton").forEach(btn => {
//     btn.addEventListener("click", e => {
//         buttonActived(btn.value);
//     })
// })

document.addEventListener("keydown", (event) => {
    console.log(event.key);
    console.log(touches);

    if (listDataKey.includes(event.key)) {
        console.log(event.key);
        buttonActived(event.key);
    }
}) 
  



function AjouterValeurCalcu(val) {
    result1.value += val;
}


function buttonActived(char) {
    switch (char) {
        case 'c':
            result1.value = "";
            result2.value = "";
            break;
        case '=':
        case "Enter":
        case " ":
            result2.value = eval(result1.value);
            break;

        default:
            console.log("Ajout: [" + char + "]");
            AjouterValeurCalcu(char)
            break;
    }
}

// window.onload = function () {

// }


