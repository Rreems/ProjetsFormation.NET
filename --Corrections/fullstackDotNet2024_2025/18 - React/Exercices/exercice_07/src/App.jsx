import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import LoginForm from './components/LoginForm'

function App() {

  const logUserInfos = (username, password) => {
    console.log(username);
    console.log(password);
  }

  return (
    <>
      <LoginForm logUserInfos={logUserInfos} />
    </>
  )
}

export default App
