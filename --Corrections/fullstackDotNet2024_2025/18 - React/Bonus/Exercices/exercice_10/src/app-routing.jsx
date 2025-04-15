import {createBrowserRouter} from "react-router-dom"
import App from "./App"
import ErrorPage from "./components/ErrorPage"
import HomePage from "./components/HomePage"
import ContactMePage from "./components/ContactMePage"
import AboutPage from "./components/AboutPage"

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    errorElement: <ErrorPage />,
    children: [
      {
        path: "/",
        element: <HomePage />
      },
      {
        path: "/contact",
        element: <ContactMePage />
      },
      {
        path: "/about",
        element: <AboutPage />
      }
    ]
  }
])

export default router