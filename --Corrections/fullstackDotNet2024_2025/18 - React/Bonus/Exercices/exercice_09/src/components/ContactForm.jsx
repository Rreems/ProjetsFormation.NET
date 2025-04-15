import { useContext, useRef } from "react";
import { ContactContext } from "../context/ContactContext";

const ContactForm = () => {
  const firstnameRef = useRef()
  const lastnameRef = useRef()
  const ageRef = useRef()

  const context = useContext(ContactContext)
  const {setContacts} = context

  const submitForm = () => {
    const firstname = firstnameRef.current.value
    const lastname = lastnameRef.current.value
    const age = ageRef.current.value

    const newContact = {id: Date.now(), firstname, lastname, age}
    setContacts((prevContacts) => [...prevContacts, newContact])
  }

  return ( 
    <>
      <div>
        <label htmlFor="nom">Nom :</label>
        <input type="text" ref={lastnameRef} />
      </div>
      <div>
        <label htmlFor="prenom">Prénom :</label>
        <input type="text" ref={firstnameRef} />
      </div>
      <div>
        <label htmlFor="age">Age :</label>
        <input type="text" ref={ageRef} />
      </div>
      <div>
        <button onClick={submitForm}>Submit</button>
      </div>
    </>
   );
}
 
export default ContactForm;