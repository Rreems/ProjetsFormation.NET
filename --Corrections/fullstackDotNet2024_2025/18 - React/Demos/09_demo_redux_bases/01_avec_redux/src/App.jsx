import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import TaskHeader from './components/Tasks/TaskHeader'
import TaskList from './components/Tasks/TasksList'
import TaskForm from './components/Tasks/TaskForm'

function App() {

  return (
    <>
      <TaskHeader />
      <TaskForm />
      <TaskList />
    </>
  )
}

export default App
