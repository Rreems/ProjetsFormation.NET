const ItemContact = ({ contactList }) => {

    return (
        <>
            {contactList.map((element, index) => {
                console.log(`Id: ${element.id}, FirstName: ${element.FirstName}`);
                return (<tr key={index}>
                    <th scope="row">{element.id}</th>
                    <td>{element.FirstName}</td>
                    <td>{element.LastName}</td>
                </tr>);
            })}
        </>
    );
}

export default ItemContact;