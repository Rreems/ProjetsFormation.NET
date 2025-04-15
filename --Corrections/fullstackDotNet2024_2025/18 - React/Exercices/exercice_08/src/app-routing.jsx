import {createBrowserRouter} from "react-router-dom"
import NavBar from "./components/NavBar"
import ContactList from "./pages/contactList"
import ContactForm from "./pages/ContactForm"
import ErrorPage from "./pages/ErrorPage"


const router = createBrowserRouter([
    {
        path: "/",
        element: <NavBar />,
        errorElement: <ErrorPage />,
        children:[
            {path: "/", element: <ContactList />},
            {path: "/add", element: <ContactForm />},
            {path: "/edit/:contactId", element: <ContactForm />},
            {path: "/delete/:contactId", element: <ContactForm />},
        ]
    }
])

export default router