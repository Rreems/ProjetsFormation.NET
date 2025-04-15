import { Moto } from "./classes/Moto.js"
import { Voiture } from "./classes/Voiture.js"

const result = document.querySelector(".result")

let kangoo = new Voiture("Renault", "Kangoo", 240000, 2003, false)
let bmw = new Moto("BMW", "R1150R Rockster", 65000, 2005)

result.innerHTML = kangoo.display()
result.innerHTML += bmw.display()