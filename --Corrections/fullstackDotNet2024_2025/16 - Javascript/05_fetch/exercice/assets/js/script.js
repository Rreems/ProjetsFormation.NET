const pokeApi = "https://pokeapi.co/api/v2/"
const nbPokemon = 1025
let currentPokemon

const fetchPokemon = async (nameOrId) => {
    const response = await fetch(pokeApi + `pokemon/${nameOrId}`)
    const data = await response.json()

    currentPokemon = {
        name: data.name,
        height: data.height,
        weight: data.weight,
        id: data.id,
        img: data.sprites["front_default"],
        abilities: data.abilities,
        types: data.types
    }
}

const resetPokemon = () => {
    document.getElementById("pokeTypes").innerHTML = ""
    document.getElementById("pokeAbilities").innerHTML = ""
}

const displayPokemon = () => {
    resetPokemon()
    document.getElementById("pokeImg").src = currentPokemon.img
    document.getElementById("pokeName").textContent = currentPokemon.name
    document.getElementById("pokeHeight").textContent = currentPokemon.height
    document.getElementById("pokeWeight").textContent = currentPokemon.weight

    for (let type of currentPokemon.types) {
        let newLi = document.createElement("li")
        newLi.textContent = type.type.name
        document.getElementById("pokeTypes").appendChild(newLi)
    }

    for (let abilitie of currentPokemon.abilities) {
        let newLi = document.createElement("li")
        newLi.textContent = abilitie.ability.name
        document.getElementById("pokeAbilities").appendChild(newLi)
    }

    document.getElementById("previousPoke").disabled = currentPokemon.id == 1
    document.getElementById("nextPoke").disabled = currentPokemon.id == nbPokemon
}

document.getElementById("searchBtn").addEventListener("click", async () => {
    let searchInput = document.getElementById("searchInput").value
    try {
        await fetchPokemon(searchInput)
        if (currentPokemon) 
        {
            displayPokemon()
            document.getElementById("searchInput").value = ""
        }
    } catch (error) {
        console.error(error);
        
    }
})

document.getElementById("previousPoke").addEventListener("click", async () => {
    try {
        await fetchPokemon(currentPokemon.id - 1)
        if (currentPokemon) displayPokemon()
    } catch (error) {
        console.error(error);
    }
})

document.getElementById("nextPoke").addEventListener("click", async () => {
    try {
        await fetchPokemon(currentPokemon.id + 1)
        if (currentPokemon) displayPokemon()
    } catch (error) {
        console.error(error);
    }
})