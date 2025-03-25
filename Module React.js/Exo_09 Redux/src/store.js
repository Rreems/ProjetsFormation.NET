import { configureStore } from "@reduxjs/toolkit";
import productsSlice from "./products/productsSlice";

export default configureStore({
    reducer: {
        product: productsSlice,
        // Possibilité d'importer d'autres slice
    }
})