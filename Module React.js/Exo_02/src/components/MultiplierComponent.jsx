import { useState } from "react";
import { useEffect } from "react";

const MultiplierComponent = () => {

    const [numberA, setNumberA] = useState(0);
    const [numberB, setNumberB] = useState(0);
    const [resultMult, setResultMult] = useState(0);

    const numberAInput = (e) => {
        setNumberA(e.target.value);
    }

    const numberBInput = (e) => {
        setNumberB(e.target.value);
    }


    
    
  // L'effet est exécuté chaque fois que myPrenom change d'état
  useEffect(() => {
    console.log("Un nombre change d'état !");
    setResultMult(Number(numberA) * Number(numberB));
  }, [numberA, numberB]);



    return (
        <>
            <input type="text" value={numberA} onInput={numberAInput} />
            <input type="text" value={numberB} onInput={numberBInput} />
            <p>Multiplication: {numberA} x {numberB} = {resultMult}</p>
        </>
    );
}

export default MultiplierComponent;

