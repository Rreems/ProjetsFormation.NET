import './App.css'

import { useSelector } from "react-redux";

import ProductList from './components/ProductList'
import AddProduct from './components/AddProduct'

function App() {

  const counter = useSelector(state => state.product.counterProducts)


    return (
      <>
        <header>
          <h1>React Product list</h1>
          <p>Produits : <strong>{counter}</strong></p>
        </header>

        <AddProduct />

        <ProductList />
      </>
    )
  }

  export default App
