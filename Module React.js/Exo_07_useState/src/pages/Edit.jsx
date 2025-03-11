import { useRef } from 'react';
import { useOutletContext } from 'react-router-dom';

const Edit = () => {

    const [listContact, setListContact] = useOutletContext();
    console.log("List en Edit:");
    console.log(listContact);
    // listContact.push({
    //     id: Math.random,
    //     nom: "marley",
    //     prenom: "bob",
    //     mail: "mail@m.com",
    //     phoneNumber: "0647474747"
    // })

    const id = useRef()
    const nom = useRef()
    const prenom = useRef()
    const mail = useRef()
    const phoneNumber = useRef()

console.log("id");
console.log(id);

    const addContact = (e) => {

        e.preventDefault()

        console.log(id.current.value);
        console.log(nom.current.value);
        console.log(prenom.current.value);
        console.log(mail.current.value);
        console.log(phoneNumber.current.value);

        setListContact(oldArray => [...oldArray, {
            id: id.current.value,
            nom: nom.current.value,
            prenom: prenom.current.value,
            mail: mail.current.value,
            phoneNumber: phoneNumber.current.value
        }]);

        console.log("List en AddContact:");
        console.log(listContact);

        // id.current.value = "";
        // nom.current.value = "";
        // prenom.current.value = "";
        // mail.current.value = "";
        // phoneNumber.current.value = "";
    }


    return (
        <>
            <div>

                Edit Page WIP

                <form onSubmit={addContact}>

                    <div>
                        <label htmlFor="id">id</label>
                        <input type="text" ref={id} />
                    </div>
                    <div>
                        <label htmlFor="nom">nom</label>
                        <input type="text" ref={nom} />
                    </div>
                    <div>
                        <label htmlFor="prenom">prenom</label>
                        <input type="text" ref={prenom} />
                    </div>
                    <div>
                        <label htmlFor="mail">mail</label>
                        <input type="text" ref={mail} />
                    </div>
                    <div>
                        <label htmlFor="phoneNumber">phoneNumber</label>
                        <input type="text" ref={phoneNumber} />
                    </div>

                    <button type='submit'>Valider</button>
                </form>

            </div>
        </>
    );
}

export default Edit;