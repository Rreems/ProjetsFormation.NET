import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import StateFullComponent from './components/StateFullComponent'
import StateLessComponent from './components/StateLessComponent'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <StateFullComponent />
      <StateLessComponent />
    </>
  )
}

export default App
