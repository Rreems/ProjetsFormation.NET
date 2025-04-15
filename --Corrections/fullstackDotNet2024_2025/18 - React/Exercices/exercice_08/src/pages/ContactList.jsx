import ContactDisplay from "../components/ContactDisplay";
import {useOutletContext} from 'react-router-dom'

const ContactList = () => {
    const [contactList] = useOutletContext()
    return ( 
        <>  
            <h1>ContactList</h1>
            {
                contactList.map(contact => [
                    <ContactDisplay contactId={contact.id} key={contact.id} />
                ])
            }
        </>
     );
}
 
export default ContactList;