import { useState, useEffect } from "react";

const MysteryNumber = ({nbMystere}) => {
    const [nbA, setNbA] = useState(0);
    const [nbB, setNbB] = useState(0);
    const [result, setResult] = useState("");

    useEffect(() => {
        if (nbA * nbB == nbMystere) {
            setResult(`La multiplication des deux nombre fait bien ${nbMystere}`)
        } else {
            setResult(`Les deux nombres multipliés ne font pas ${nbMystere}...`)
        }
    }, [nbA, nbB, nbMystere]);

    return ( 
        <>
            <input type="number" value={nbA} onInput={(e) => setNbA(+e.target.value)} />
            <input type="number" value={nbB} onInput={(e) => setNbB(+e.target.value)} />
            <p>{result}</p>
        </>
     );
}
 
export default MysteryNumber;