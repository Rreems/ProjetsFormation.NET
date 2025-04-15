import { useState } from "react";
import {useDispatch} from "react-redux"
import { deleteProduct, updateProduct } from "./productSlice";
import { useRef } from "react";

const ProductItem = ({product}) => {
    const dispatch = useDispatch()
    const [update, setUpdate] = useState(false);
    const name = useRef()
    const price = useRef()

    const submitProduct = () => {
        const updatedProduct = {
            id: product.id,
            name: name.current.value,
            price: price.current.value
        }

        dispatch(updateProduct(updatedProduct))
        setUpdate(!update)
    }
    return ( 
        <>
            {
                update ?
                <tr>
                    <td><input type="text" className="form-control" ref={name} defaultValue={product.name} /></td>
                    <td><input type="number" className="form-control" ref={price} defaultValue={product.price} /></td>
                    <td>
                        <button onClick={submitProduct} className="btn btn-success">Valider</button>
                        <button onClick={() => {setUpdate(!update)}} className="btn btn-danger">Annuler</button>
                    </td>
                </tr>
                :
                <tr>
                <td>{product.name}</td>
                <td>{product.price} €</td>
                <td>
                    <button onClick={() => {setUpdate(!update)}} className="btn btn-success">Modifier</button>
                    <button onClick={() => dispatch(deleteProduct(product.id))} className="btn btn-danger">Supprimer</button>
                </td>
            </tr>
            }
        </>
     );
}
 
export default ProductItem;