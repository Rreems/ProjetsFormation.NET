import {createBrowserRouter} from 'react-router-dom'
import App from './App'
import Login from './components/Login'
import Profil from './components/Profil'
import ProtectedRoute from './components/ProtectedRoute'


const router = createBrowserRouter([
    {
        path: "/",
        element: <App />
    },
    {
        path: "/login",
        element: <Login />
    },
    {
        path: "/profil",
        element : <ProtectedRoute><Profil /></ProtectedRoute>
    }
])

export default router