const DisplayProduct = ({product, addItemToCart}) => {
    return ( 
        <div className="card">
            <div className="card-body">
                <h5 className="card-title">{product.name}</h5>
                <p className="card-text">{product.description}</p>
                <p className="card-text">Prix : {product.price} €</p>
                <button className="btn btn-primary" onClick={() => addItemToCart(product)}>Ajouter au panier</button>
            </div>
        </div>
     );
}
 
export default DisplayProduct;