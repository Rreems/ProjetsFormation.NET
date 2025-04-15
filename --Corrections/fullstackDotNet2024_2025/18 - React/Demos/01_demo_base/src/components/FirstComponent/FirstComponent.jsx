import classes from "./FirstComponent.module.css"
import logoM2i from "../../assets/images/m2i.webp"
import TableRow from "../TableRow/TableRow"

const FirstComponent = () => {
    let nom = "Toto"

    let maListe = ["toto", "tata", "titi"]

    const ditBonjour = () => {
        return "Bonjour " + nom
    }

    console.log("Hello world");
    return ( 
        <>
            <h1 className={classes.redTitle} >FirstComponent</h1>
            {/* <p>Bonjour {nom}</p> */}
            <p>{ditBonjour()}</p>
            <img src={logoM2i} alt="logoM2i" />
            <table>
                <thead>
                    <tr>
                        <th>ColA</th>
                        <th>ColB</th>
                        <th>ColC</th>
                    </tr>
                </thead>
                <tbody>
                    <TableRow />
                    <TableRow />
                    <TableRow />
                </tbody>
            </table>
            <ul>
                {maListe.map((prenom, index) => <li key={index}>{prenom}</li>)}
            </ul>
        </>
     );
}
 
export default FirstComponent;