import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import DemoUseMemo from './components/DemoUseMemo'
import CounterComponent from './components/CounterComponent'
import { MonPremierContext } from './contexts/MonPremierContext'
import InputComponent from './components/InputComponent'

function App() {
  const [nom, setNom] = useState("Toto")

  return (
    <>
      <MonPremierContext.Provider  value={{nom, setNom}}>
        <DemoUseMemo />
        <CounterComponent />
        <InputComponent />
      </MonPremierContext.Provider>
    </>
  )
}

export default App
