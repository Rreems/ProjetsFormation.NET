import { useSelector } from "react-redux";
import ProductItem from "./ProductItem";

const ProductList = () => {
    
    const tasks = useSelector(state => state.product.products)

    return ( 
        <>
            {
                tasks.map((product) => (
                    <ProductItem product={product} key={product.id} />
                ))
            }        
        </>
     );
}
 
export default ProductList;