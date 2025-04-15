import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Outlet } from "react-router-dom";
import "./App.css";
import Header from "./components/header/Header";
import Modal from "./components/modal/Modal";
import PokedexDisplay from "./components/pokemon/pokedexDisplay/PokedexDisplay";
import { fetchPokemons, fetchType } from "./components/pokemon/pokemonSlice";

function App() {
  const displayPokedex = useSelector((state) => state.pokemons.displayPokedex);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(fetchPokemons());
    dispatch(fetchType());
  }, []);

  return (
    <>
      <header>
        <Header />
      </header>
      <main>
        {displayPokedex && (
          <Modal>
            <PokedexDisplay />
          </Modal>
        )}
        <Outlet />
      </main>
    </>
  );
}

export default App;
