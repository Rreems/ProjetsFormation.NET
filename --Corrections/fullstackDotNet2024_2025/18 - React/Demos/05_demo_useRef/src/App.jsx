import { useState, useRef } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import Modal from './components/Modal/Modal';
import FormComponent from './components/FormComponent';

function App() {
  const [isOpen, setIsOpen] = useState(false);

  return (
    <>
      <h1>Bienvenue sur mon site</h1>
      <button onClick={() => setIsOpen(!isOpen)}>Ouvrir</button>
      {isOpen && <Modal closeModal={() => setIsOpen(!isOpen)}><FormComponent /></Modal>}
    </>
  )
}

export default App
