import { useState } from "react";
import { useEffect } from "react";

const BonjourComponent = () => {

    const [myPrenom, setmyPrenom] = useState("Bob");
    const [myNom, setmyNom] = useState("Dylan");

    const [chrono, setChrono] = useState(0);    

    const prenomInput = (e) => {
        setmyPrenom(e.target.value);
    }

    const nomInput = (e) => {
        let nom = e.target.value
        setmyNom(nom);
    }

    // Exécuté qu'au lancement de l'appli / Montage du Component
    useEffect(() => {
        // console.log("Appli lancée.");
    });

    
  // L'effet est exécuté chaque fois que myPrenom change d'état
  useEffect(() => {
    console.log("myPrenom change d'état !");
  }, [myPrenom]);


  // L'effet est exécuté à chaque re-render du composant
  useEffect(() => {
   setInterval(() => {
    setChrono(chrono + 1)
   },1000) 
  });


    return (
        <>
            <input type="text" value={myPrenom} onInput={prenomInput} />
            <input type="text" value={myNom} onInput={nomInput} />
            <p>Bonjour <b>{myPrenom} {myNom.toUpperCase()}</b>, bienvenue sur l'application !</p>
            <p>{chrono}</p>
        </>
    );
}

export default BonjourComponent;

