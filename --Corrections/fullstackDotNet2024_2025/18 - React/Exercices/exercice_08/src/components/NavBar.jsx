import { useState } from "react";
import {Outlet, Link} from "react-router-dom"

const NavBar = () => {
    const [contactList, setContactList] = useState([
        {id: 1, firstname: "Toto", lastname: "Toto", email: "toto@email.fr", phone: "0605040102"}
    ]);
    
    return ( 
        <>
            <nav>
                <div>
                    <Link to={"/"}>ContactList</Link>
                </div>
                <div>
                    <Link to={"/add"}>Add contact</Link>
                </div>
            </nav>
            <div>
                <Outlet context={[contactList, setContactList]} />
            </div>
        </>
     );
}
 
export default NavBar;