import { useState } from "react";

const StateLessFizzbuzz = () => {

    const [nombreBuzz, setNombreBuzz] = useState(1);

    const [myText, setmyText] = useState("");

    const increment = () => {
        setNombreBuzz(prev => prev + 1)
    }

    const decrement = () => {
        setNombreBuzz(prev => prev - 1)
    }

    const fizzbuzzDisplay = () => {

        if (nombreBuzz % 15 == 0) return "FizzBuzz"
        if (nombreBuzz % 3 == 0)  return "Fizz"
        if (nombreBuzz % 5 == 0) return "Buzz"

        return  nombreBuzz;
    }

    const textInput = (e) => {
        console.log(e.target.value);
        setmyText(e.target.value);
    }

    return (
        <>
            <h1>Le Zuper FIZZ BUZZ ╰(*°▽°*)╯</h1>
            <p>Nombre ({nombreBuzz}): {fizzbuzzDisplay()}</p>

            <button disabled={nombreBuzz <= 1} className="btn btn-warning" onClick={decrement}>-1</button>
            <button disabled={nombreBuzz >= 100} className="btn btn-info" onClick={increment}>+1</button>

            <input type="text" value={myPrenom} onInput={textInput}/>
            <input type="text" value={myNom} onInput={textInput}/>
            <p>Bonjour {myPrenom}  [NOM DE FAMILLE], bienvenue sur l'application !"</p>
        </>
    );
}

export default StateLessFizzbuzz;