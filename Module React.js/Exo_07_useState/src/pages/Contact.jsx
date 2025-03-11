import { useState } from "react";
import { Link, Outlet } from "react-router-dom";
import { useOutletContext } from 'react-router-dom';

const Contact = () => {

    const {id} = useParams()
    const [searchParams] = useSearchParams()

    const [listContact, setlistContact] = useOutletContext();

    console.log("List en page Contact:");
    console.log(listContact);

    


    return (
        <>
            WIP liste contacts--

            <table className="table">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Nom</th>
                        <th scope="col">Prénom</th>
                        <th scope="col">Mail</th>
                        <th scope="col">Téléphone</th>
                    </tr>
                </thead>
                <tbody>

                    {listContact.map((c) =>
                        <tr>
                            <th scope="row">{c.id}</th>
                            <td>{c.nom}</td>
                            <td>{c.prenom}</td>
                            <td>{c.mail}</td>
                            <td>{c.phoneNumber}</td>
                        </tr>
                    )}

                </tbody>
            </table>

        </>
    );
}

export default Contact;