import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import ProductList from './components/products/ProductList'
import ProductForm from './components/products/ProductForm'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <ProductList />
      <ProductForm />
    </>
  )
}

export default App
