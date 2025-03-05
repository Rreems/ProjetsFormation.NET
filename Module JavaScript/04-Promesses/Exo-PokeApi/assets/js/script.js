const apiUrl = "https://pokeapi.co/api/v2/pokemon";

const inputId = document.querySelector(".inputPokemon")

const resultBox = document.querySelector(".resultPokemon");
const pokemonName = document.querySelector(".pokemonName");
const pokemonImg = document.querySelector(".pokemonImg");
const pokemonDetails = document.querySelector(".pokemonDetails");

const buttonLeft = document.querySelector(".buttonLeft");
const buttonRight = document.querySelector(".buttonRight");

const buttonSearch = document.querySelector(".buttonSearch");

let pokemonIdActuel ;

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


// GET by ID
const getPostId = async (id) => {

    try {
        let response = await fetch(`${apiUrl}/${id}`); // Requete GET pour récup les Posts de l'API
        let data = await response.json()  // Conversion de la réponse en JSON
        // console.log(data);
        pokemonIdActuel = id
        return data

    } catch (error) {
        console.error(error);
    }
}


buttonSearch.addEventListener("click", (event) => {
    pokemonIdActuel = inputId.value ;
    AfficherPokemon(pokemonIdActuel);
});


buttonLeft.addEventListener("click", (event) => {
    if ( pokemonIdActuel > 1 ){
        pokemonIdActuel-- ;
        AfficherPokemon(pokemonIdActuel);
    }
});

buttonRight.addEventListener("click", (event) => {
    if ( pokemonIdActuel < 1304 ){
        pokemonIdActuel++ ;
        AfficherPokemon(pokemonIdActuel);
    }
});

 async function AfficherPokemon(id){
    let pokemon = await getPostId(id)

    console.log("Pokemon num: " + pokemonIdActuel);
    console.log(pokemon);

    inputId.value = pokemonIdActuel;
    resultBox.removeAttribute("hidden");
    pokemonName.innerHTML= pokemon.name ;
    pokemonImg.src = pokemon.sprites.front_default;

    let list ="";
    pokemon.types.forEach(c => list+=c.type.name+ ", ");
    console.log(list);

    pokemonDetails.innerHTML = `${list} <br> ${pokemon.weight}lbs `;
}




