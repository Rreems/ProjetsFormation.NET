import classes from "./FirstComponent.module.css"
import logoReaction from "../../assets/images/reaction.png"
import TableRow from "../TableRow/TableRow";

const FirstComponent = () => {

    // Logique JS juste ici
    let nombre = 23;

    const ditBonjour = (nom) => {
        return "Bonjour " + nom + ".";
    }    

    console.log(`Nombre: ${nombre}`);

    let maListe = ["Toto", "Tata", "Tutu"]

    return (
         // Balise vide: pas de création en HTML, plus propre
        <>  
            <h1 className={classes.redTitle}>Bienvenue 😊</h1>

            <p>Mon nombre est: {nombre}</p>

            <p>{ditBonjour("Toto")}</p>

            <img src={logoReaction} width={20} height={25} alt='Reaction chimique :o' ></img>
            
            <table>
                <thead>
                    <tr>
                        <th>Col A</th>
                        <th>Col B</th>
                        <th>Col C</th>
                    </tr>
                </thead>
                <tbody>
                    <TableRow/>
                    <TableRow/>
                    <TableRow/>
                </tbody>
            </table>

            <ul>
                {maListe.map((prenom, index) => <li key={index}>{prenom}</li>)}
            </ul>
        </>
     );
}
 
export default FirstComponent;