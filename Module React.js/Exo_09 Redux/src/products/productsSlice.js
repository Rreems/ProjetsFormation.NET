import {createSlice} from "@reduxjs/toolkit"


const productSlice = createSlice({
    name: "product",
    initialState: {
        // ici, nous retrouverons nos variables d'état
        products : [
            { id: 1, name: "Noix de coco", price: 7.5 },
            { id: 2, name: "Mangue", price: 4 }
        ],
        counterProducts: 2
    },
    reducers: {
        // state : Contenu de initialState
        // action: élément envoyé à notre store {type: "Product/a1dProduct", payload}
        // payload: est un objet contenant les paramètres de la fonction
        addProduct : (state, action) => {
            console.log("Add:");
            console.log(action.payload);

            const newProduct = {
                id: Date.now(),
                name: action.payload[0],
                price: action.payload[1]
            }

            state.products.push(newProduct)
            state.counterProducts += 1
        },
        deleteProduct : (state, action) => {
            state.products = state.products.filter((Product) => Product.id != action.payload)
            state.counterProduct -= 1
        }
    }
})

export const {addProduct, deleteProduct} = productSlice.actions
export default productSlice.reducer