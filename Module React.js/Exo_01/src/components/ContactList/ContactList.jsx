const ContactList = () => {

    const contactList = []
    contactList.push({
        id: 1,
        FirstName: "Albert",
        LastName: "DUPONT"
    })
    contactList.push({
        id: 2,
        FirstName: "Marc",
        LastName: "DUPONT"
    })
    contactList.push({
        id: 3,
        FirstName: "Jeanne",
        LastName: "MERCIER"
    })

    return (
        <>
            <ul>

            </ul>

            <table className="table table-striped table-hover caption-top">
                <caption>Mes superbes personnes</caption>
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">First Name</th>
                        <th scope="col">Last Name</th>
                    </tr>
                </thead>
                <tbody>

                    {contactList.map(element => {
                        console.log(`Id: ${element.id}, FirstName: ${element.FirstName}`);
                        return (<tr>
                            <th scope="row">{element.id}</th>
                            <td>{element.FirstName}</td>
                            <td>{element.LastName}</td>
                        </tr>);
                    })}
                </tbody>
            </table>

        </>
    );
}

export default ContactList;