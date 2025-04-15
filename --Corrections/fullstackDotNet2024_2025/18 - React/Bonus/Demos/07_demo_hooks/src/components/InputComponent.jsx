import { useContext } from "react";
import { MonPremierContext } from "../contexts/MonPremierContext";

const InputComponent = () => {
  const value = useContext(MonPremierContext)

  return ( 
    <>
      <input type="text" value={value.nom} onInput={(e) => value.setNom(e.target.value)}  />
      <p>Mon nom : {value.nom}</p>
    </>
   );
}
 
export default InputComponent;