import { useState } from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css'
import TodoItemForm from './components/TodoItemForm';
import TodoItemDisplay from './components/TodoItemDisplay';

function App() {
  const [todo, setTodo] = useState([])

  const addTodo = (newTodo) => {
    setTodo([...todo, newTodo])
  }

  const deleteTodo = (todoId) => {
    setTodo([...todo.filter(todo => todo.id != todoId)])
  }

  const switchTodoStatus = (todoId) => {
    const oldTodo = todo.find(todo => todo.id === todoId)
    if(oldTodo) {
      oldTodo.isDone = !oldTodo.isDone
      setTodo([...todo.filter(todo => todo.id != todoId), oldTodo])
    }
  }

  return (
    <div className='container'>
      <div className='row my-3 g-2'>
        <div className='col-4'>
          <div className='p-3 bg-dark rounded text-light'>
              <TodoItemForm addTodo={addTodo} />
          </div>
        </div>
        <div className='col-8'>
          <div className='p-3 bg-dark rounded text-light'>
            <h3>Todos</h3>
            <hr />
            {todo.length === 0 && <p>Il n'y a pas de todo pour le moment</p>}
            {todo.length > 0 && todo.sort((x,y) => x.id - y.id).map((todo, index) => <TodoItemDisplay key={index} deleteTodo={() => deleteTodo(todo.id)} 
            switchTodoStatus={() => switchTodoStatus(todo.id)} todo={todo} />)}
          </div>
        </div>
      </div>
    </div>
  )
}

export default App
