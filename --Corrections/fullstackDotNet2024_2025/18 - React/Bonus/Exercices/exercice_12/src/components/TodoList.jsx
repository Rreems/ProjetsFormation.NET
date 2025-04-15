import { useState } from "react";
import { useEffect } from "react";
import axios from "axios"
import {Link} from "react-router-dom"

const TodoList = () => {
  const [todos, setTodos] = useState([])

  useEffect(() => {
    axios.get('http://localhost:3000/todos')
      .then(response => {
        setTodos(response.data)
      })
  }, [])

  return ( 
    <>
      <h1>Todo List</h1>
      <ul>        
        {
          todos.map((todo) => (
            <li key={todo.id}>{todo.titre} 
            <Link to={`detail/${todo.id}`}>Voir les détails</Link>
            </li>
          ))
        }
      </ul>
      <Link to={"/add"}>Ajouter une todo</Link>
    </>
   );
}
 
export default TodoList;