import { useState } from 'react'
import './App.css'
import FirstComponent from './components/FirstComponent/FirstComponent'
import 'bootstrap/dist/css/bootstrap.min.css'
import ContactList from './components/ContactList/ContactList'

function App() {
  const [count, setCount] = useState(0)

  return (
    <div> 
      {/* <FirstComponent/> */}

      <ContactList/>
    </div>
  )
}

export default App
