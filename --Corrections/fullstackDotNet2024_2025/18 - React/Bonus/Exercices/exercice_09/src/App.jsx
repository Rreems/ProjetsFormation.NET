import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import { ContactContext } from './context/ContactContext'
import ContactForm from './components/ContactForm'
import CardDisplay from './components/CardDisplay'

function App() {
  const [contacts, setContacts] = useState([])

  return (
    <>
      <ContactContext.Provider value={{contacts, setContacts}} >
        <ContactForm />
        {
          contacts.map((contact) => (
            <CardDisplay key={contact.id} contactId={contact.id} />
          ))
        }
      </ContactContext.Provider>
    </>
  )
}

export default App
