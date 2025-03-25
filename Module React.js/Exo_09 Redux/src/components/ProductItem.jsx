import { useDispatch } from "react-redux";
import { deleteProduct } from "../products/productsSlice"

const ProductItem = ({product}) => {

    const dispatch = useDispatch()

    return ( 
        <>
        <div className="box">
            <label>
                {product.name} - {product.price}€
            </label>
            <span
                onClick={() => dispatch(deleteProduct(product.id))}
                role="button"
                style={{ padding: "5px", marginLeft: "20px" }}
            >
                X
            </span>
        </div>        
        </>
     );
}
 
export default ProductItem;