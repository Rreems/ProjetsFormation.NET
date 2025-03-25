import { useState } from "react";
import { useEffect } from "react";
import DisplayListContact from "../DisplayListContact/DisplayListContact";

const ContactInputComponent = () => {


    const [myPrenom, setMyPrenom] = useState("Bob");
    const [myNom, setMyNom] = useState("Dylan");
    const [myMail, setMyMail] = useState("bob.dylan@gmail.com");


    const [listContact, setListContact] = useState([]);


    const prenomInput = (e) => {
        setMyPrenom(e.target.value);
    }

    const nomInput = (e) => {
        let nom = e.target.value
        setMyNom(nom);
    }

    const mailInput = (e) => {
        let nom = e.target.value
        setMyMail(nom);
    }

    const validerButton = () => {
        console.log(`Ajout contact: \nNom:${myNom}\nPrenom:${myPrenom}\nMail:${myMail}`);

        setListContact(oldArray => [...oldArray, {
            nom: myNom,
            prenom: myPrenom,
            mail: myMail
        }]);
    }

    const listContactDisplay = () => {
        console.log("ok");
        <ul>

        {listContact.map((row, index)=> {
            <li>- a</li>
        })}

        </ul>
    }

    return (
        <>
            <h1>Créez un contact:</h1>
            <input type="text" value={myPrenom} onInput={prenomInput} />
            <input type="text" value={myNom} onInput={nomInput} />
            <input type="text" value={myMail} onInput={mailInput} />

            <button onClick={validerButton}>Ajouter</button>

            <div>
                {/* {listContact.length == 0 && <p>La liste est vide.</p>}
                {listContact.length > 0 && listContactDisplay} */}
                <DisplayListContact listContact={listContact} />
            </div>
        </>
    );
}

export default ContactInputComponent;