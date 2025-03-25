import classes from './PanierModal.module.css'
import { createPortal } from "react-dom"

import { useOutletContext } from 'react-router-dom'
import ArticlePanierModal from './ArticlePanierModal.jsx'


const PanierModal = ({ children, closeModal, context }) => {


    const [listArticle, setListArticle, data] = context;

    const totalCost = () => {
        let tot = 0;
        listArticle.map(article => {
            tot += article.price * article.quantity
        }
        );
        return tot
    }

    return createPortal(
        <div className={classes.modal}>
            <div className={classes.modalContent}>

                <ul className="list-group">
                    {listArticle.map(article => (

                        <ArticlePanierModal Id={article.id} context={context}/>

                    ))}
                </ul>

                <p>Prix total: {totalCost()}€</p>

                <button onClick={closeModal}>Fermer</button>
            </div>
        </div>,
        document.body
    )
}

export default PanierModal;