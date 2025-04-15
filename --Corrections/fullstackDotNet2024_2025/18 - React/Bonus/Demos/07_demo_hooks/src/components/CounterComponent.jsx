import { useContext } from "react";
import { useCounter } from "../hooks/useCounter";
import { MonPremierContext } from "../contexts/MonPremierContext";

const CounterComponent = () => {
  const {count, increment, decrement} = useCounter()
  const value = useContext(MonPremierContext)

  return ( 
    <>

      <p>Count : {count} - {value.nom}</p>
      <button onClick={increment}>+</button>
      <button onClick={decrement}>-</button>
    </>
   );
}
 
export default CounterComponent;