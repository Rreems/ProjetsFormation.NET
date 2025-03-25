import { Outlet, Link } from "react-router-dom"

import { useState, useEffect } from 'react'
import axios from "axios"

import PanierModal from './PanierModal/PanierModal';


const NavBar = () => {

    const [articleList, setArticleList] = useState([]);
    const [isOpen, setIsOpen] = useState(false);


    const [data, setData] = useState();

    useEffect(() => {
        axios.get("http://localhost:3000/articles")
        .then(response => {
          console.log(response.data);
          setData(response.data)
        })
        .catch(error => console.error(error))
    }, []);



    return (
        <>
            <nav className="navbar navbar-expand-lg navbar-dark bg-light ">
                <div>
                    E-commerce app - taille panier: {articleList.length}    
                </div>
                <div>
                    {articleList.length > 0 && <button onClick={() => setIsOpen(!isOpen)}>Panier</button>}
                    {isOpen && <PanierModal closeModal={() => setIsOpen(!isOpen)} context={[articleList, setArticleList, data]}></PanierModal>}
                    {/* {isOpen && <PanierModal closeModal={() => setIsOpen(!isOpen)}><ViewPanier /></PanierModal>} */}
                </div>
            </nav>

            <div>
                <Outlet context={[articleList, setArticleList, data]} />
            </div>
        </>
    );
}

export default NavBar;