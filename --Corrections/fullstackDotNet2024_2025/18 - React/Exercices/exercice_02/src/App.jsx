import { useState } from 'react'
import './App.css'

function App() {
  let listing = [1,2,3,4]


  const addNumber = () => {
    listing.push(5)
    console.log(listing);
  }

  return (
    <>
      <ul>
        {
          listing.map((nb, index) => <li key={index}>{nb}</li>)
        }
      </ul>
      <button onClick={addNumber}>Ajouter un nombre</button>
    </>
  )
}

export default App
