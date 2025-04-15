import { Link } from "react-router-dom";
import classes from "./PokemonCard.module.css";

const PokemonCard = (props) => {
  return (
    <>
      {props.pokemon && (
        <Link to={"/pokemon/" + props.pokemon.id} className={classes.card}>
          <img
            src={props.pokemon.sprites.other.showdown.front_default}
            alt="pokemon_img"
          />
          <h5>#{props.pokemon.id}</h5>
          <h1>{props.pokemon.name}</h1>
        </Link>
      )}
    </>
  );
};

export default PokemonCard;
