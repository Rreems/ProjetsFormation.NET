import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import ParentComponent from './components/ParentComponent'
import ChildrenComponent from './components/ChildrenComponent'
import 'bootstrap/dist/css/bootstrap.min.css'
import Button from './components/ui/Button'


function App() {

  const sayHello = () => {
    console.log("Hello");
  }
  return (
    <>
      <ParentComponent />
      <ChildrenComponent>Test</ChildrenComponent>
      <ChildrenComponent>Test2</ChildrenComponent>
      <ChildrenComponent>Test3</ChildrenComponent>
      <Button onClick={sayHello}>Valider</Button>
      <Button>Supprimer</Button>

    </>
  )
}

export default App
