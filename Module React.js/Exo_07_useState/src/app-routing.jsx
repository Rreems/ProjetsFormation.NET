import {createBrowserRouter} from "react-router-dom"
import ErrorPage from "./pages/ErrorPage"
import NavBar from "./components/NavBar"
import Contact from "./pages/Contact"
import Edit from "./pages/Edit"

const router = createBrowserRouter([
    // {path: "/", element: <HomePage />, errorElement: <ErrorPage />},
    // {path: "/form", element: <FormPage />, errorElement : <ErrorPage />}
    {
        path: "/",
        element: <NavBar />,
        errorElement: <ErrorPage />,
        children: [
            {path: "/", element: <Contact />},
            {path: "/contacts", element: <Contact />},
            {path: "/contacts/:id", element: <Contact />},
            {path: "/contacts/edit/:id?&:mode?", element: <Edit />},
        ]
    }
])

export default router