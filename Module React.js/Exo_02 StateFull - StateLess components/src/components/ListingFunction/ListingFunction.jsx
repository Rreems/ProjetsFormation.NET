import ItemContact from "../ItemContact/ItemContact.jsx";

let contactList = [{
    id: 1,
    FirstName: "Albert",
    LastName: "DUPOND"
}];


const addToList = () => {
    console.log("Add");
    console.log(contactList);

    // contactList.contactList.push({

    contactList.push({
        id: 1,
        FirstName: "Marco",
        LastName: "POLO "
    });
}


const ListingFunction = () => {
    return (
        <>
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
                    <ItemContact contactList={contactList} />
                </tbody>
            </table>

            <button type="button" onClick={() => { addToList() }}>Clic</button>

        </>
    );
}

export default ListingFunction;