import {createBrowserRouter} from "react-router-dom"
import NavBar from "./components/Navbar"
import ArticleShop from "./components/Pages/ArticleShop"
import ErrorPage from "./components/Pages/ErrorPage"


const router = createBrowserRouter([
    {
        path: "/",
        element: <NavBar />,
        errorElement: <ErrorPage />,
        children:[
            {path: "/", element: <ArticleShop />},
        ]
    }
])

export default router