const DisplayListContact = ({listcontact}) => {

    console.log("List:");
    console.log(listcontact);
    console.log(listcontact);

    return(
        <>
        {
            listcontact.length > 0 ?
            <h1>Pas vide</h1>

            : 
            <h1>Très vide.</h1>
        }
        </>
    )
}

export default DisplayListContact;