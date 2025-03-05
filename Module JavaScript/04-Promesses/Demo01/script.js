

function doThing() {

    return new Promise((resolve, reject) => {
        setTimeout(() => {
            let random = Math.random();
            console.log(random);

            if (random < 0.5) {
                resolve("Tout est cool:" + random)
            } else {
                reject("Erreur random.")
            }
        });
    }, 2000);
}

//////////   Méthode plus ancienne
// const boutonCall = document.querySelector(".buttonCall").addEventListener("click", ()=>{
//     doThing()
//     .then((response) => {
//         console.log(response);
//     })
//     .catch((error)=>{
//         console.error(error);
//     })
// })

////////// Nouvelle méthode !
document.querySelector(".buttonCall").addEventListener("click", async () => {


    try {
        let random = Math.random();
        console.log(random);
    } catch (error) {
        console.error(error)
    }

})


const apiUrl = "https://jsonplaceholder.typicode.com/posts";

//READ 
const getPosts = async () => {
    try {
        let response = await fetch(apiUrl) // Requete GET pour récup les Posts de l'API
        let data = await response.json()  // Conversion de la réponse en JSON
        console.log(data);

    } catch (error) {
        console.error(error);
    }
}

// CREATE
const createPost = async () => {
    let newPost = {
        title: "Mon nouveau post",
        body: "Le contenu super",
        userId: "1"
    }

    try {
        let response = await fetch(apiUrl, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
                // 'Authorisation' : 'Bearer monToken'
            },
            body: JSON.stringify(newPost)
        })

        console.log(response);
        console.log("Statut de ma réponse: " , response.status);
        let data = await response.json();
        console.log(data);

    } catch (error) {
        console.error(error);
    }
}


// GET by ID
const getPostId = async () => {
    let id = prompt("Entrez l'Id:")

    try {
        let response = await fetch(`${apiUrl}/${id}`); // Requete GET pour récup les Posts de l'API
        let data = await response.json()  // Conversion de la réponse en JSON
        console.log(data);

    } catch (error) {
        console.error(error);
    }
}

// UPDATE
const updatePost = async () => {
    let updatePost = {
        title: "Titre modifié",
        body: "Body modifié",
        userId: "1"
    }

    let id = prompt ("Entrez l'Idd à modifier:")

    try {
        let response = await fetch(`${apiUrl}/${id}` , {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
                // 'Authorisation' : 'Bearer monToken'
            },
            body: JSON.stringify(updatePost)
        })

        console.log(response);
        console.log("Statut de ma réponse: " , response.status);
        let data = await response.json();
        console.log(data);

    } catch (error) {
        console.error(error);
    }
}

// DELETE
const deletePost = async () => {

    let id = prompt ("Entrez l'Idd à modifier:")

    try {
        let response = await fetch(`${apiUrl}/${id}` , {
            method: "DELETE"
        })

        console.log(response);
        console.log("Statut de ma réponse: " , response.status);

    } catch (error) {
        console.error(error);
    }
}