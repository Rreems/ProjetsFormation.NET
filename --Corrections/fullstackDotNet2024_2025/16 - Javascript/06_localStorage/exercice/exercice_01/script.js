const addToCart = (name) => {
    let cart = JSON.parse(localStorage.getItem("cart")) || []

    let existingProduct = cart.find((product) => product.name == name)

    if (existingProduct) {
        existingProduct.quantity++
    } else {
        cart.push({name: name, quantity : 1})
    }

    localStorage.setItem("cart", JSON.stringify(cart))
    loadCart()
}

const removeProduct = (name) => {
    let cart = JSON.parse(localStorage.getItem("cart")) || []

    let productIndex = cart.findIndex((product) => product.name == name)

    if(productIndex != -1){
        if(cart[productIndex].quantity > 1){
            cart[productIndex].quantity--
        } else {
            cart.splice(productIndex, 1)
        }
    }
    localStorage.setItem("cart", JSON.stringify(cart))
    loadCart()
}

const loadCart = () => {
    let cart = JSON.parse(localStorage.getItem("cart")) || []
    const cartList = document.querySelector(".cartList")
    cartList.innerHTML = ""

    if (cart.length == 0) {
        cartList.innerHTML = "<li>Le panier est vide</li>"
    } else {
        cart.forEach(product => {
            let li = document.createElement("li")
            li.innerHTML = `${product.name} - Quantitée : ${product.quantity}
                            <button onclick="removeProduct('${product.name}')">-</button>`
            cartList.appendChild(li)
        });
    }
}

window.onload = loadCart()