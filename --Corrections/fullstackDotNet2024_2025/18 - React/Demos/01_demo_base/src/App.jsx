import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import FirstComponent from './components/FirstComponent/FirstComponent'
import 'bootstrap/dist/css/bootstrap.min.css'
import Conditionnal from './components/Conditionnal'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <FirstComponent />
      {/* <FirstComponent />
      <FirstComponent />
      <FirstComponent /> */}
      <Conditionnal />
    </>
  )
}

export default App
