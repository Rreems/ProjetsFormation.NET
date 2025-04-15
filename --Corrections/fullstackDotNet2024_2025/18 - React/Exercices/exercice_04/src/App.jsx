import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {
  const [firstname, setFirstname] = useState("");
  const [lastname, setLastname] = useState("");

  const firstnameInput = (e) => {
    setFirstname(e.target.value)
  }

  const lastnameInput = (e) => {
    setLastname(e.target.value)
  }

  const getFullName = () => {
    const formatedLastname = lastname.toUpperCase()

    return firstname + " " + formatedLastname
  }

  return (
    <>
      <input type="text" value={firstname} onInput={firstnameInput} placeholder='Prénom' />
      <input type="text" value={lastname} onInput={lastnameInput} placeholder='Nom' />
      <p>Bonjour, <b>{getFullName()}</b>, bienvenue sur l'application !</p>
      {/* <p>Bonjour, <b>{firstname} {lastname.toUpperCase()}</b>, bienvenue sur l'application !</p> */}
    </>
  )
}

export default App
