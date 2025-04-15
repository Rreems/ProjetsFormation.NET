import { useRef } from "react";
import { useDispatch, useSelector } from "react-redux";
import PokemonCard from "../pokemonCard/PokemonCard";
import { setFilteredPokemons } from "../pokemonSlice";
import classes from "./PokemonList.module.css";

const PokemonList = () => {
  const dispatch = useDispatch();
  const typeRef = useRef();
  const pokemons = useSelector((state) => state.pokemons.pokemons);
  const types = useSelector((state) => state.pokemons.types);
  const filteredPokemons = useSelector(
    (state) => state.pokemons.filteredPokemons
  );

  const handleChange = () => {
    const type = typeRef.current.value;
    if (type === "ALL") {
      dispatch(setFilteredPokemons(pokemons));
    } else {
      const filtered = pokemons.filter((pokemon) => {
        return pokemon.types.map((type) => type.type.name).includes(type);
      });
      dispatch(setFilteredPokemons(filtered));
    }
  };

  return (
    <>
      <div>
        <select className="mt-3" ref={typeRef} onChange={handleChange}>
          <option value="All">All</option>
          {types.map((type, key) => (
            <option key={key} value={type.name}>
              {type.name}
            </option>
          ))}
        </select>
      </div>
      <div className={classes.cardContainer}>
        {filteredPokemons?.map((pokemon, key) => (
          <PokemonCard pokemon={pokemon} key={key} index={pokemon.id} />
        ))}
      </div>
    </>
  );
};

export default PokemonList;
