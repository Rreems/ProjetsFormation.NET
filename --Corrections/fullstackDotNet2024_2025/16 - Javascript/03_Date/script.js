const btnIn = document.querySelector(".in")
const btnOut = document.querySelector(".out")
let inTime, outTime

let maDate = new Date()

console.log(maDate);

setTimeout(() => {
    console.log("5 secondes plus tard...");
    console.log(new Date());
}, 5000)

btnIn.addEventListener("click", () => {
    inTime = new Date()
})

btnOut.addEventListener("click", () => {
    outTime = new Date()
    alert((outTime - inTime) / 1000)
})