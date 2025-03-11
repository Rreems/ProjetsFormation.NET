import { useState } from "react";

const StateLessComp = () => {

    const [monPrenom, setMonPrenom] = useState("Toto");

    const changerPrenom = () => {
        setMonPrenom ("Titi") ;
    }

    return (
        <>
            <h1>Stateless Comp</h1>
            <p>Prénom: {monPrenom}</p>

            <button onClick={changerPrenom}>Titi</button>
        </>
    );
}

export default StateLessComp;