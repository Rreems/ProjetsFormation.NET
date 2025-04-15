import {createBrowserRouter} from "react-router-dom"
import HomePage from "./pages/HomePage"
import FormPage from "./pages/FormPage"
import ErrorPage from "./pages/ErrorPage"
import NavBar from "./components/NavBar"
import Profil from "./pages/Profil"

const router = createBrowserRouter([
    // {path: "/", element: <HomePage />, errorElement: <ErrorPage />},
    // {path: "/form", element: <FormPage />, errorElement : <ErrorPage />}
    {
        path: "/",
        element: <NavBar />,
        errorElement: <ErrorPage />,
        children: [
            {path: "/", element: <HomePage />},
            {path: "/form", element: <FormPage />},
            {path: "/profil/:id", element: <Profil />}
        ]
    }
])

export default router