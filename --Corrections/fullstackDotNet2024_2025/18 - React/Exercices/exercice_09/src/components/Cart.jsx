const Cart = ({cart, removeItemFromCart}) => {
    const total = cart.reduce((totalPrice, item) => totalPrice + item.price * item.quantity, 0)

    return ( 
        <div className="card">
            <div className="card-body">
                <h2 className="card-title">Panier</h2>
                {
                    cart.length == 0 ? (
                        <p className="card-text">Votre panier est vide</p>
                    ) : (
                        <ul className="list-group">
                            {
                                cart.map(item => (
                                    <li key={item.id} className="list-group-item">
                                        {item.name} - {item.price} € (quantité : {item.quantity})
                                        <button className="btn btn-danger" onClick={() => removeItemFromCart(item)}>Supprimer</button>
                                    </li>
                                ))
                            }
                        </ul>
                    )
                }
                <p className="card-text">Total : {total.toFixed(2)} €</p>
            </div>
        </div>
     );
}
 
export default Cart;