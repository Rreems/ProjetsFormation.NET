import { useContext } from "react";
import { ContactContext } from "../context/ContactContext";

const LogButton = ({contactId}) => {
  const context = useContext(ContactContext)
  const foundContact = context.contacts.find(contact => contact.id === contactId)

  const logInfo = () => {
    console.log(foundContact);
  }

  return ( 
      <button onClick={logInfo}>Details</button>
   );
}
 
export default LogButton;