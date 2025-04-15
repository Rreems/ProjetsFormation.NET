import { Voiture } from "./classes/Voiture.js"

const result = document.querySelector(".result")

let bmw = new Voiture("bmw", "Serie 1", 80)
let mercedes = new Voiture("Mercedes", "GLB", 100)

result.innerHTML += bmw.accelerer()
result.innerHTML += bmw.accelerer()
result.innerHTML += bmw.accelerer()

result.innerHTML += mercedes.accelerer()
result.innerHTML += mercedes.accelerer()
result.innerHTML += mercedes.tourner()
result.innerHTML += mercedes.tourner()