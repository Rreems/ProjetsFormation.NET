import {createBrowserRouter} from "react-router-dom"
import TodoList from "./components/TodoList"
import AddTodo from "./components/AddTodo"
import TodoDetail from "./components/TodoDetail"

const router = createBrowserRouter([
  {
    path: "/",
    element: <TodoList />
  },
  {
    path: "/add",
    element: <AddTodo />
  },
  {
    path: "/detail/:id",
    element: <TodoDetail />
  },
])

export default router