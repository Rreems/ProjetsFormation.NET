import {useParams, useSearchParams, useOutletContext, useNavigate} from "react-router-dom"

const ContactForm = () => {
    const {contactId} = useParams()
    const [searchParams] = useSearchParams()
    const [contactList, setContactList] = useOutletContext()
    const mode = searchParams.get("mode") ?? "add"
    const contact = contactList.find(contact => contact.id == contactId)
    const navigate = useNavigate()

    const submitForm = (formData) => {
        if (mode == "delete") {
            setContactList(prevContacts => prevContacts.filter(contact => contact.id != contactId))
        } else if (mode == "edit") {
            const updatedContact = {
                id: contactId,
                firstname: formData.get("firstname"),
                lastname: formData.get("lastname"),
                phone: formData.get("phone"),
                email: formData.get("email")
            }

            setContactList(prev => prev.map(contact => contact.id == contactId ? updatedContact : contact))
        } else {
            const newContact = {
                id: Date.now(),
                firstname: formData.get("firstname"),
                lastname: formData.get("lastname"),
                phone: formData.get("phone"),
                email: formData.get("email")
            }

            setContactList(prev => [...prev, newContact])
        }
        navigate("/")
    }

    return ( 
        <>
            <h1>{mode} Contact</h1>
            <form action={submitForm}>
                <div>
                    <label htmlFor="firstname">Firstname</label>
                    <input type="text" name="firstname" disabled={mode == "delete"} defaultValue={contact?.firstname} />
                </div>
                <div>
                    <label htmlFor="lastname">Lastname</label>
                    <input type="text" name="lastname" disabled={mode == "delete"} defaultValue={contact?.lastname}  />
                </div>
                <div>
                    <label htmlFor="email">Email</label>
                    <input type="text" name="email" disabled={mode == "delete"} defaultValue={contact?.email} />
                </div>
                <div>
                    <label htmlFor="phone">Phone</label>
                    <input type="text"  name="phone" disabled={mode == "delete"} defaultValue={contact?.phone} />
                </div>
                <button type="submit">{mode}</button>
            </form>
        </>
     );
}
 
export default ContactForm;