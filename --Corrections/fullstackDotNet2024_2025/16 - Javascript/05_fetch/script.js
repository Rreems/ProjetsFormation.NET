const apiUrl = "https://jsonplaceholder.typicode.com/posts"

// READ
const getPosts = async () => {
    try {
        let response = await fetch(apiUrl) // Requête GET pour récupérer les posts
        let data = await response.json() // Conversion de la réponse en format JSON
        console.log(data);
    } catch (error) {
        console.error(error);
    }
}

// CREATE
const createPost = async () => {
    let newPost = {
        title: "Mon nouveau post",
        body: "Le contenu de mon nouveau post",
        userId: 1
    }

    try {
        let response = await fetch(apiUrl, {
            method: "POST", // Méthode HTTP POST pour créer un nouveau post
            headers: {
                "Content-Type": "application/json"
                // 'Authorization': 'Bearer votreToken'
            },
            body: JSON.stringify(newPost) // Corps de la requête avec le contenu du nouveau post
        })
        
        console.log(response);
        console.log("status de ma reponse : ", response.status);
        let data = await response.json()
        console.log(data);
    } catch (error) {
        console.error(error);
    }
}

// Fonction pour récupérer un post via l'id
const getPostId = async () => {
    let id = prompt("Entrez l'id : ")

    try {
        let response = await fetch(`${apiUrl}/${id}`) // Requête GET pour récupérer les posts
        let data = await response.json() // Conversion de la réponse en format JSON
        console.log(data);
    } catch (error) {
        console.error(error);
    }
}

// UPDATE
const updatePost = async () => {
    let updatePost = {
        title : "Titre modifié",
        body: "Body modifié",
        userId: 1
    }

    let id = prompt("Entrez l'id à modifié : ")

    try {
        const response = await fetch(`${apiUrl}/${id}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(updatePost)
        })
        const data = await response.json()
        console.log(data);        
    } catch (error) {
        console.error();
    }
}

// DELETE

const deletePost = async () => {
    let id = prompt("Entrez l'id à supprimer : ")
    try {
        const response = await fetch(`${apiUrl}/${id}`, {
            method: "DELETE"
        })
        console.log(response);        
    } catch (error) {
        console.error(error);
    }
}