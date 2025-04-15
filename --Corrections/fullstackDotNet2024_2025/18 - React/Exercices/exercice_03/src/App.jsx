import { useState } from 'react'
import './App.css'

function App() {
  const [count, setCount] = useState(99)

  const fizzBuzzRender = () => {
    if (count % 15 === 0) {
      return "FizzBuzz"
    } else if (count % 5 === 0) {
      return "Buzz"
    } else if (count % 3 === 0) {
      return "Fizz"
    } else {
      return count
    }
  }

  // const incre = () => {
  //   setCount(count + 1)
  //   console.log(count);
  // }

  return (
    <>
     <p>{fizzBuzzRender()}</p>
     <button onClick={() => setCount(count + 1)} disabled={count >= 100}>+</button>
     <button onClick={() => setCount(count - 1)} disabled={count <= 1}>-</button>
    </>
  )
}

export default App
