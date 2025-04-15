import {Outlet, Link} from "react-router-dom"
import './App.css'

function App() {

  return (
    <>
      <nav>
        <Link to={"/"}>HomePage</Link>
        <Link to={"/about"}>AboutPage</Link>
        <Link to={"/contact"}>ContactMePage</Link>
      </nav>
      <main>
        <Outlet />
      </main>
    </>
  )
}

export default App
