import { useState } from "react";
import { Link, Outlet } from "react-router-dom";

const NavBar = () => {

    const [listContacts, setListContacts] = useState([
        {
            id: 1,
            nom: "Adminos",
            prenom: "admin",
            mail: "mail@m.com",
            phoneNumber: "0133456"
        }
    ]);

    console.log("En Navbar:");
    console.log(listContacts);

    return (
        <>
            <nav className="navbar navbar-expand-lg navbar-dark bg-dark ">
                <a className="navbar-brand" href="#">Supers contacts</a>
                <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarText">
                    <ul className="navbar-nav mr-auto">
                        <li className="nav-item active">
                            <Link to={"/"}>Liste Contacts</Link>
                        </li>
                        <li className="nav-item">
                            <Link to={"/contacts/edit/?mode=create"}>Créer contact</Link>
                        </li>
                    </ul>
                </div>
            </nav>


            <div className="main">
                <Outlet context={[listContacts, setListContacts]} />
            </div>


            <footer>Mon pied de page.</footer>
        </>
    );
}

export default NavBar;

