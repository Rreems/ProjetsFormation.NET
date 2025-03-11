import { useRef } from 'react'
import './App.css'
import FormComponent from './components/formComponent'

function App() {
  

  const Connection = (Login, Password) => {
    console.log("Connexion en cours...");
    console.log(`Login: ${Login}\nMot de passe: ${Password}`);
  }


  return (
    <>

    <h1>Hello, user.</h1>

    <FormComponent onConnection={Connection} ></FormComponent>
    
    </>
  )
}

export default App
