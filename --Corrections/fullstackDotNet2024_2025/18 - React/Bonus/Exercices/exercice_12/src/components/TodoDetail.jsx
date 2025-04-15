import { useState, useEffect } from "react"
import {useParams, useNavigate} from "react-router-dom"
import axios from "axios"

const TodoDetail = () => {
  const navigate = useNavigate()
  const {id} = useParams()
  const [todo, setTodo] = useState(null)

  useEffect(() => {
    axios.get(`http://localhost:3000/todos/${id}`)
      .then(response => {
        setTodo(response.data)
      })
  }, [])

  const deleteTodo = () => {
    axios.delete(`http://localhost:3000/todos/${id}`)
    .then(() => {
      console.log("La todo avec l'id" + id + " supprimée.");
      navigate("/")
    })
  }

  const modifTodo = () => {
    navigate(`/add?id=${id}`)
  }

  if(!todo) {
    return <p>Chargement...</p>
  } else {
    return ( 
      <>  
        <h1>Detail todo</h1>
        <p>{todo.titre}</p>
        <button onClick={deleteTodo}>Supprimer</button>
        <button onClick={modifTodo}>Modifier</button>
      </>
     );
  }

}
 
export default TodoDetail;