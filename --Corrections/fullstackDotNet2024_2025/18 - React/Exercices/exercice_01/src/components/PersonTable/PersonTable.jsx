const PersonTable = () => {
    let contacts = [
        {"firstname": "Albert", "lastname": "DUPONT"},
        {"firstname": "Maria", "lastname": "DUPONT"},
        {"firstname": "Chloé", "lastname": "DUPONT"},
        {"firstname": "Sylvia", "lastname": "MARTEZ"},
    ]


    return ( 
        <>
            <h1>Mes contacts</h1>
            <hr />
            <table className="table table-dark">
                <thead>
                    <tr>
                      <th>#</th>  
                      <th>Firstname</th>  
                      <th>Lastname</th>  
                    </tr>
                </thead>
                <tbody>
                    {
                        contacts.map((person, index) => {
                            return (
                            <tr key={index}>
                                <td>{index + 1}</td>
                                <td>{person.firstname}</td>
                                <td>{person.lastname}</td>
                            </tr>
                        )})
                    
                    }
                </tbody>
            </table>
        </>
     );
}
 
export default PersonTable;