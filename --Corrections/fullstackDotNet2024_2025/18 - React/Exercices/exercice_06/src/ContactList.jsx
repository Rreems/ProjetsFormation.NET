const ContactList = ({contacts}) => {
    return ( 
        <>
            {
                contacts.length > 0 ? 
                <table>
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Prénom</th>
                            <th>Nom</th>
                            <th>Email</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            contacts.map((contact, index) => (
                                <tr key={index}>
                                    <td>{index+1}</td>
                                    <td>{contact.firstname}</td>
                                    <td>{contact.lastname}</td>
                                    <td>{contact.email}</td>
                                </tr>
                            ))
                        }
                    </tbody>
                </table>
                :
                <p>Il n'y a pas de contacts pour le moment</p>
            }
        </>
     );
}
 
export default ContactList;