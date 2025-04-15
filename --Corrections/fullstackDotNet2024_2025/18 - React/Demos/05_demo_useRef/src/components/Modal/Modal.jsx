import classes from './Modal.module.css'
import {createPortal} from "react-dom"

const Modal = ({children, closeModal}) => {
    
    return createPortal(
        <div className={classes.modal}>
            <div className={classes.modalContent}>
                {children}
                <button onClick={closeModal}>Fermer</button>
            </div>
        </div>,
        document.body
    )
}
 
export default Modal;