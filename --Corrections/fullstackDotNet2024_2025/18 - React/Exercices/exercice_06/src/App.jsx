import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import ContactList from './ContactList';
import ContactForm from './ContactForm';

function App() {
  const [contacts, setContacts] = useState([]);

  const addContact = (contact) => {
    setContacts(previousContact => [...previousContact, contact])
  }

  return (
    <>
     <ContactList contacts={contacts} />
     <ContactForm addContact={addContact} />
    </>
  )
}

export default App
