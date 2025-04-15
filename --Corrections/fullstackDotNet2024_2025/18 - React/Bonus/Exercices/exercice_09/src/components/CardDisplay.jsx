import { useContext } from "react";
import { ContactContext } from "../context/ContactContext";
import LogButton from "./LogButton";

const CardDisplay = ({contactId}) => {
  const context = useContext(ContactContext)
  const foundContact = context.contacts.find(contact => contact.id === contactId)

  return (  
    <>
      <p>{foundContact.firstname} {foundContact.lastname} - {foundContact.age} ans</p>
      <LogButton contactId={contactId} />
    </>
  );
}
 
export default CardDisplay;