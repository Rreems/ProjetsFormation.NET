import { useMemo } from "react"
import { useState } from "react"
import { useCounter } from "../hooks/useCounter"

const items = Array(10_000_000).fill(0).map((_, index) => {
  return {
    id: index,
    isFavorite: index === 9_999_999
  }
})

const DemoUseMemo = () => {
  const {count, increment, decrement} = useCounter()
  const [counter, setCounter] = useState(0)

  const favItem = useMemo(() => items.find((e) => e.isFavorite), [])

  return (  
    <>
      <p>count : {count}</p>
      <span>{favItem.id}</span>
      <button onClick={() => setCounter(counter+1)}>{counter}</button>
    </>
  );
}
 
export default DemoUseMemo;