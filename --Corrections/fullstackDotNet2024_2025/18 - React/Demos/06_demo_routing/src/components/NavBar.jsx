import { useState } from "react";
import { Link, Outlet } from "react-router-dom";

const NavBar = () => {
    const [contactList, setContactList] = useState(["test"]);
    return ( 
        <>
            <nav>
                <Link to={"/"}>HomePage</Link>
                <Link to={"/form"}>Formulaire</Link>
            </nav>
            <div className="main">
                <Outlet context={[contactList, setContactList]} />
            </div>
            <footer>Mon pied de page</footer>
        </>
     );
}
 
export default NavBar;