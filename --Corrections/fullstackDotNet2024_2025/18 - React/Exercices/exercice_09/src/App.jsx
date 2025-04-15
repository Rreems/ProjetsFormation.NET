import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import { useEffect } from 'react';
import axios from "axios"
import DisplayProduct from './components/DisplayProduct';
import Modal from './components/Modal/Modal'
import Cart from './components/Cart';


function App() {
  const [products, setProducts] = useState([]);
  const [cart, setCart] = useState([]);
  const [displayCart, setDisplayCart] = useState(false);

  useEffect(() => {
    axios.get("http://localhost:3000/products")
    .then(response => setProducts(response.data))
    .catch(error => console.error(error))

    axios.get("http://localhost:3000/cart")
    .then(response => setCart(response.data))
    .catch(error => console.error(error))
  }, []);

  const displayModal = () => {
    setDisplayCart(!displayCart)
  }

  const addItemToCart = (item) => {
    const existingItem = cart.find((cartItem) => cartItem.id == item.id)

    if (existingItem) {
      const updatedItem = {
        ...existingItem,
        quantity: existingItem.quantity + 1
      }
      axios.put(`http://localhost:3000/cart/${existingItem.id}`, updatedItem)
      .then(() => setCart(cart.map((cartItem) => cartItem.id == existingItem.id ? updatedItem : cartItem)))
      .catch(error => console.error(error))
    } else {
      const newItem = {...item, quantity : 1}
      axios.post("http://localhost:3000/cart", newItem)
      .then(() => setCart(prev => [...prev, newItem]))
      .catch(error => console.error(error))
    }
  }

  const removeItemFromCart = (item) => {
    const existingItem = cart.find((cartItem) => cartItem.id == item.id)

    if (existingItem) {
      if (existingItem.quantity > 1) {
        const updatedItem = {
          ...existingItem,
          quantity: existingItem.quantity - 1
        }

      axios.put(`http://localhost:3000/cart/${existingItem.id}`, updatedItem)
      .then(() => setCart(cart.map((cartItem) => cartItem.id == existingItem.id ? updatedItem : cartItem)))
      .catch(error => console.error(error))
      } else {
        axios.delete(`http://localhost:3000/cart/${existingItem.id}`)
        .then(() => setCart(cart.filter((cartItem) => cartItem.id != existingItem.id)))
      }
    }
  }

  return (
    <>
      {displayCart && (<Modal closeModal={() => displayModal()}><Cart cart={cart} removeItemFromCart={removeItemFromCart} /></Modal>)}
      <nav className='navbar navbar-exband-lg bg-body-tertiary'>
        <div className='navbar-brand'>
            E-Commerce-App
        </div>
        <button className='btn btn-primary ms-auto' onClick={() => displayModal()}>Panier</button>
      </nav>
      <div className='container mt-4'>
        <div className='row'>
          {
            products.map((product) => (
              <div key={product.id} className='col-md-4 mb-4'>
                <DisplayProduct product={product} addItemToCart={addItemToCart} />
              </div>
            ))
          }
        </div>
      </div>
    </>
  )
}

export default App
