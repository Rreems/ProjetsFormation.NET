import { Voiture } from "./classes/Voiture.js"

const divText = document.querySelector(".divText");
const inputVoiture = document.querySelector(".inputVoiture");
const buttonPay = document.querySelector(".buttonPay");
const buttonTicket = document.querySelector(".buttonTicket");

let parkingTab = [];

buttonPay.addEventListener("click", (event) => {
    PayerTicket(inputVoiture.value);
});


buttonTicket.addEventListener("click", (event) => {
    SortirTicket(inputVoiture.value);
});




function PayerTicket(idPlaque) {
    console.log("Fonction payer pour voiture:" + idPlaque);

    let voitureGaree = parkingTab.find(o => o.plaque === idPlaque);

    if (voitureGaree && voitureGaree.dateOut == null) {
        voitureGaree.dateOut = new Date();
        let timeParked = (voitureGaree.dateOut - voitureGaree.dateIn) / 1000;
        console.log("date in " + voitureGaree.dateIn);
        console.log("date out " + voitureGaree.dateOut);
        console.log("timeParked:" + timeParked);

        let tarif = 0;
        switch (true) {
            case timeParked <= 3:  //   < 15min en situation réelle
                console.log("C moins de 3sec");
                tarif = 0.8;
                break;
            case timeParked <= 8:  //   < 30min en situation réelle
                console.log("C moins de 8sec");
                tarif = 1.3;
                break;
            case timeParked <= 13:  //   < 15min en situation réelle
                console.log("C moins de 13sec");
                tarif = 1.7;
                break;
            default: // > 45min en situation réelle
                console.log("Temp supérieur à 45min");
                tarif = 6;
                break;
        }
        divText.innerHTML = `Vous êtes resté garé ${timeParked}minutes, ça vous coutera ${tarif}€.`
        divText.classList.remove('backgroundWhite');
        divText.classList.add('backgroundGreen');
        resetDivText();

    }
    else {
        console.log("Voiture pas encore garée ! ");
        divText.innerHTML = "Votre voiture n'est pas garée !"
        divText.classList.remove('backgroundWhite');
        divText.classList.add('backgroundRed');
        resetDivText();
    }
}





function SortirTicket(idPlaque) {
    console.log("Fonction ticket pour voiture:" + idPlaque);

    console.log("Trouvaille: " + parkingTab.find(o => o.plaque === idPlaque));
    if (!parkingTab.find(o => o.plaque === idPlaque)) {
        parkingTab.push(new Voiture(idPlaque))

        // console.log(`Veuillez prendre votre ticket pour votre voiture immatriculée ${idPlaque}.`);
        divText.innerHTML = `Veuillez prendre votre ticket pour votre voiture immatriculée ${idPlaque}.`;
        divText.classList.remove('backgroundWhite');
        divText.classList.add('backgroundGreen');
        console.log(parkingTab);
        resetDivText();
    }
    else {
        divText.classList.remove('backgroundWhite');
        divText.classList.add('backgroundRed');
        divText.innerHTML = "Voiture déjà garée !!!!"
        resetDivText();
        console.log("Voiture déjà garée !");
    }
}



function resetDivText() {
    setTimeout(() => {
        console.log("4 secondes plus tard...");
        divText.innerHTML = ""
        divText.classList.add('backgroundWhite');
        divText.classList.remove('backgroundRed');
    }, 4000)
}
