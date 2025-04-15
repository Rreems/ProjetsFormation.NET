import { useState, useEffect } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {
  const [firstname, setFirstname] = useState("");
  const [lastname, setLastname] = useState("");
  const [fullname, setFullname] = useState("");
  const [chrono, setChrono] = useState(0);

  // L'effet est exécuté au lancement de l'application
  useEffect(() => {
    console.log("Application démarrée");
  }, []);

  // L'effet est exécuté chaque fois que firstname change d'état
  useEffect(() => {
    console.log("Firstname change d'état !");
    setFullname(firstname + " " + lastname)
  }, [firstname, lastname]);

  // L'effet est exécuté à chaque re-render du composant
  useEffect(() => {
   setInterval(() => {
    setChrono(chrono + 1)
   },1000) 
  });

  return (
    <>
      <input type="text" value={firstname} onInput={(e) => setFirstname(e.target.value)} placeholder='firstname'/>
      <input type="text" value={lastname} onInput={(e) => setLastname(e.target.value)} placeholder='lastname'/>
      <p>{fullname}</p>
      <p>{chrono}</p>
    </>
  )
}

export default App
