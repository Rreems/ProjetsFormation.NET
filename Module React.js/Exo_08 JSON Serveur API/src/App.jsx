import { useState, useEffect } from 'react'
import axios from "axios"
import 'bootstrap/dist/css/bootstrap.css';
import './App.css'

import PanierModal from './components/PanierModal/PanierModal';

function App() {

  // const dataArticles 

  const [isOpen, setIsOpen] = useState(false);

  return (
    <>

      <div className="flex-container">
        <div>1</div>
        <div>2</div>
        <div>3</div>
        <div>4</div>
        <div>5</div>
      </div>

      <h1>Bienvenue sur mon site</h1>
      <button onClick={() => setIsOpen(!isOpen)}>Ouvrir</button>
      {isOpen && <PanierModal closeModal={() => setIsOpen(!isOpen)}></PanierModal>}
    </>
  )
}

export default App
