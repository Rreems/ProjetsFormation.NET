import { Voiture } from "./classes/Voiture.js"

const btnPayer = document.querySelector("#payementBtn")
const btnEnter = document.querySelector("#enterBtn")
const successBox = document.querySelector("#successBox")
const warningBox = document.querySelector("#warningBox")
const dangerBox = document.querySelector("#dangerBox")
const licencePlate = document.querySelector("#licencePlate")

let parking = []

function displayBox(message, box){
    box.style.display = "block"
    box.textContent = message

    setTimeout(() => {
        box.style.display = "none"
    }, 3000)
}

btnEnter.addEventListener("click", () => {
    let voiture = parking.find(voiture => {
        return voiture.licencePlate == licencePlate.value
    })

    if (voiture == undefined) {
        parking.push(new Voiture(licencePlate.value))
        displayBox(`Veuillez prendre votre ticket pour la voiture : ${licencePlate.value}`, successBox)
        licencePlate.value = ""
        console.table(parking);
    } else {
        displayBox(`Le véhicule ${licencePlate.value} est déjà dans le parking !`, dangerBox)
    }

})

btnPayer.addEventListener("click", () => {
    let voiture = parking.find(voiture => {
        return voiture.licencePlate == licencePlate.value
    })

    if(voiture != undefined){
        voiture.endDate = new Date()
        let duree = Math.round((voiture.endDate - voiture.startDate) / 60000)
        let prix
        console.log(voiture);
        console.log(duree);
        switch(true) {
            case duree <= 15:
                prix = 0.8
                break
            case duree <= 30:
                prix = 1.3
                break
            case duree <= 45:
                prix = 1.7
                break
            default:
                prix = 6
                break
        }

        displayBox(`Le prix à payer pour le véhicule : ${voiture.licencePlate} est de ${prix} €`, warningBox)
    } else {
        displayBox(`le véhicule ${licencePlate.value} n'est pas dans le parking`, dangerBox)
    }
})

function init(){
    parking.push(new Voiture("AA-123-AA", new Date("2025-03-03T08:00:00")))
    parking.push(new Voiture("BB-123-AA", new Date("2025-03-03T09:25:00")))
    parking.push(new Voiture("BB-123-CC", new Date("2025-03-03T08:50:00")))

    successBox.style.display = "none"
    warningBox.style.display = "none"
    dangerBox.style.display = "none"
}

window.onload = init()