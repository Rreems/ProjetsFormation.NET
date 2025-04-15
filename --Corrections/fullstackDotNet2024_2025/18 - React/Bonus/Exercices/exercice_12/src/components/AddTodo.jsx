import { useRef } from "react";
import {useNavigate, useSearchParams} from "react-router-dom"
import axios from "axios"
import { useEffect } from "react";

const AddTodo = () => {
  const titleRef = useRef()
  const navigate = useNavigate()
  const [params] = useSearchParams()
  const id = params.get("id") ?? null

  useEffect(() => {
    axios.get(`http://localhost:3000/todos/${id}`)
    .then((response) => {
      titleRef.current.value = response.data.titre
    })
  }, [])

  const handleSubmit = () => {
    if(id != null) {
      axios.put(`http://localhost:3000/todos/${id}`, {titre: titleRef.current.value})
      .then(() => navigate("/"))
    } else {
      axios.post(`http://localhost:3000/todos`, {titre: titleRef.current.value})
      .then(() => navigate("/"))
    }
  }

  return (  
    <>
      <h1>Ajout todo</h1>
      <input type="text" ref={titleRef} />
      <button onClick={handleSubmit}>{id ? "Modifier todo" : "Ajouter todo"}</button>
    </>
  );
}
 
export default AddTodo;