// Pour effectuer une fonctionnalité qui peut prendre un certain temps à s'effectuer, il faut utiliser une promesse

// une promesse est un objet JS qui va avoir en paramètre du constructeur deux fonction (ces deux paramètres seront des callback)

// Le premier sera la résolution de notre promesse (resolve) et le second sera la gestion de l'erreur (reject)

function doTask() {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            let random = Math.random()
            console.log(random);
            if(random > 0.5){
                resolve("Tout s'est bien passé")
            } else {
                reject(new Error("Il y a eu une erreur"))
            }
        }, 2000)
    })
}

document.querySelector(".doTaskBtn").addEventListener("click", () => {
    // .then() servira à réaliser une fonctionnalité lors de la résolution positive de la promesse (resolve)
    // .catch() servira à réaliser la fonctionnalité lors de l'echec de la promesse (reject)
    doTask()
    .then((response) => {
        console.log(response);
    })
    .catch((error) => {
        console.error(error);
    })
})

document.querySelector(".doTaskAsyncBtn").addEventListener("click", async () => {
    // Depuis Es6, il est possible d'utiliser 'async' et 'await'.
    
    // pour gérer les erreurs, il faut maintenant utiliser le bloc TRY...CATCH
    // try pour placer les instructions qui peuvent poser problème et envoyer des erreurs
    // catch pour gérer les erreurs
    try {
        let result = await doTask()
        console.log("Etape 1 finie");
        let result2 = await doTask()
        console.log("Etape 2 finie");
        console.log(result2);
    } catch (error) {
        console.error(error);
    }

})