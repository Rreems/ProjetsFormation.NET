import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import MysteryNumber from './components/MysteryNumber'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <MysteryNumber nbMystere={10} />
    </>
  )
}

export default App
