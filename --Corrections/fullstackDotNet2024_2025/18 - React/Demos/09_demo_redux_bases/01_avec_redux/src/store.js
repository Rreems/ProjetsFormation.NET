import { configureStore } from "@reduxjs/toolkit";
import taskSlice from "./components/Tasks/TaskSlice"

export default configureStore({
    reducer: {
        task: taskSlice,
        // Possibilité d'importer d'autres slice
    }
})