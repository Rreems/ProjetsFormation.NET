import {useOutletContext, Link} from 'react-router-dom'

const ContactDisplay = ({contactId}) => {
    const [contactList] = useOutletContext()
    const contact = contactList.find(contact => contact.id == contactId)

    return ( 
        <>
            <h3>{contact.firstname} {contact.lastname}</h3>
            <p>Email : {contact.email}</p>
            <p>Phone : {contact.phone}</p>
            <Link to={`/delete/${contact.id}?mode=delete`}>Delete</Link>
            <Link to={`/edit/${contact.id}?mode=edit`}>Edit</Link>
        </>
     );
}
 
export default ContactDisplay;