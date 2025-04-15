import { useState, useEffect } from 'react'
import axios from "axios"

import './App.css'

function App() {
  const [data, setData] = useState();

  useEffect(() => {
      axios.get("http://localhost:3000/todos")
      .then(response => {
        console.log(response.data);
        setData(response.data)
      })
      .catch(error => console.error(error))
  }, []);

  const addPerson = () => {
    axios.post("http://localhost:3000/todos", {name : "Toto"})
    .then(response => {
      setData(prev => [...prev, response.data])
    })
    .catch(error => console.error(error))
  }

  const deletePerson = () => {
    const id = "b840"

    axios.delete(`http://localhost:3000/todos/${id}`)
    .then(() => console.log(`La personne avec l'id : ${id} est correctement supprimée`))
    .catch(error => console.error(error))
  }

  const updatePerson = () => {
    const id = "4cc4"

    axios.put(`http://localhost:3000/todos/${id}`, {name : "Tata"})
    .then(response => console.log(response.data))
    .catch(error => console.error(error))
  }

  return (
    <>
      <button onClick={addPerson}>Add</button>
      <button onClick={deletePerson}>Delete</button>
      <button onClick={updatePerson}>Update</button>
      {
        data && (
          <ul>
            {
            data.map(contact => (
              <div key={contact.id}>
                <li>
                  {contact.name}
                </li>
              </div>
              
            ))
          }
          </ul>
        )
      }
    </>
  )
}

export default App
