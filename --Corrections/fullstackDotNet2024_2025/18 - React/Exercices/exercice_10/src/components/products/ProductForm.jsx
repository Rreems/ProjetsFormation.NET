import {useDispatch} from "react-redux"
import { addProduct } from "./productSlice"

const ProductForm = () => {
    const dispatch = useDispatch()

    const formSubmit = (formData) => {
        dispatch(addProduct({name: formData.get("name"), price: formData.get("price")}))
    }
    return ( 
        <>
            <h1>Ajouter un produit</h1>
            <form action={formSubmit}>
                <div className="row m-1">
                    <label htmlFor="name">Nom du produit :</label>
                    <input type="text" className="form-control" name="name" />
                </div>
                <div className="row m-1">
                    <label htmlFor="price">Prix du produit :</label>
                    <input type="number" className="form-control" name="price" step={0.01} />
                </div>
                <button type="submit" className="btn btn-success">Valider</button>
            </form>
        </>
     );
}
 
export default ProductForm;