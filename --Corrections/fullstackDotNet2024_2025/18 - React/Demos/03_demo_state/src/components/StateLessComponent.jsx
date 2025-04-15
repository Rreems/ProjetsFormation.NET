import { useState } from "react";

const StateLessComponent = () => {
    const [monPrenom, setMonPrenom] = useState("Toto");
    const [age, setAge] = useState(20);
    const [myText, setMyText] = useState("");

    const changerPrenom = () => {
        setMonPrenom("Titi")
    }

    const changerAge = () => {
        setAge(previousAge => previousAge + 1)
    }

    const textInput = (e) => {
        console.log(e.target.value);
        setMyText(e.target.value)
    }

    console.log("test");
    return ( 
        <>
            <h1>StateLessComponent</h1>
            <p>{monPrenom} - {age}</p>
            <button onClick={changerPrenom}>Changer prénom</button>
            <button onClick={changerAge}>Changer age</button>
            <input type="text" value={myText} onInput={textInput} />
            <p>Mon texte : {myText}</p>
        </>
     );
}
 
export default StateLessComponent;