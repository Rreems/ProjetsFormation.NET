import { useState, useLayoutEffect } from "react";
import { useParams, useSearchParams } from "react-router-dom";

const Profil = () => {
    const {id} = useParams()
    const [user, setUser] = useState();
    const [searchParams] = useSearchParams()

    const users = [
        {
            id: 1,
            name: "Toto",
            email: "toto@email.fr"
        },
        {
            id: 2,
            name: "Tata",
            email: "tata@email.fr"
        },
        {
            id: 3,
            name: "Titi",
            email: "titi@email.fr"
        },
    ]

    useLayoutEffect(() => {
        let newUser = users.find(user => user.id == id)
        console.log(searchParams?.get("darkMode"));
        console.log(searchParams?.get("mode"));
        setUser(newUser)
    }, [])

    return ( 
        <>
            <div>
                <h1>Ma page pour {user?.name}</h1>
                <p>email : {user?.email}</p>
                <p>{searchParams?.get("darkMode")}</p>
            </div>
        </>
     );
}
 
export default Profil;