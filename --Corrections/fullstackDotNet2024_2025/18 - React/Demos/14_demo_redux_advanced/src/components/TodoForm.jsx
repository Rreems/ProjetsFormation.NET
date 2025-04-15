import { useRef } from "react";
import {useDispatch} from "react-redux"
import { postTodo } from "./todoSlice";

const TodoForm = () => {
  const dispatch = useDispatch()
  const titleRef = useRef()

  const addTodo = (e) => {
    e.preventDefault()

    const newTodo = {
      title: titleRef.current.value,
      done: false
    }

    dispatch(postTodo(newTodo))
  }

  return ( 
    <>
      <input type="text" ref={titleRef} />
      <button onClick={addTodo}>Ajouter</button>
    </>
   );
}
 
export default TodoForm;