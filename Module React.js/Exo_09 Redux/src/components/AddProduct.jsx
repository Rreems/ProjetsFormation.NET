import { useDispatch } from "react-redux";
import { addProduct } from "../products/productsSlice";

const AddProduct = () => {

    const dispatch = useDispatch()

    const handleSubmit = (formData) => {
        dispatch(addProduct([formData.get("text"), formData.get("price")]))
    }

    return (
        <form action={handleSubmit}>
            <input type="text" name="text" placeholder="Ajouter un produit" />
            <input type="text" name="price" placeholder="prix" />
            <button type="submit">
                Ajouter l'article
            </button>
        </form>
    );

    <>
    </>
}

export default AddProduct;