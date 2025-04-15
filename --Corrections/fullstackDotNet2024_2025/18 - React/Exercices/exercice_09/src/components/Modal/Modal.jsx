import classes from './Modal.module.css'
import {createPortal} from "react-dom"

const Modal = ({children, closeModal}) => {
    
    return createPortal(
        <div className={classes.modal}>
            <div className={classes.modalContent}>
                {children}
                <button onClick={closeModal} className='btn btn-primary'>Fermer</button>
            </div>
        </div>,
        document.getElementById('modal')
    )
}
 
export default Modal;