import { useState } from 'react'
import './App.css'
import 'bootstrap/dist/css/bootstrap.min.css'
import ListingFunction from "./components/ListingFunction/ListingFunction.jsx"
import StateFullComp from './components/StateFullComp/StateFullComp.jsx'
import StateLessComp from './components/StateLessComp/StateLessComp.jsx'
import StateLessFizzbuzz from './components/StateLessFizzbuzz/StateLessFizzbuzz.jsx'
import BonjourComponent from './components/BonjourComponent.jsx'
import MultiplierComponent from './components/MultiplierComponent.jsx'

function App() {
  const [count, setCount] = useState(0)

  return (
    <div>
     {/* <ListingFunction/> 

     <StateFullComp/>

     <StateLessComp/> */}

     {/* <StateLessFizzbuzz/> */}

      {/* <BonjourComponent/> */}

      <MultiplierComponent></MultiplierComponent>
    </div>
  )
}

export default App



