import {createSlice} from "@reduxjs/toolkit"

// Ici, nous retrouverons et traiterons les différentes données

const taskSlice = createSlice({
    name: "task",
    initialState: {
        // ici, nous retrouverons nos variables d'état
        tasks : [
            { id: 1, text: "Faire les courses", done: false },
            { id: 2, text: "Faire le menage", done: true },
        ],
        counterTask: 1
    },
    reducers: {
        // state : Contenu de initialState
        // action: élément envoyé à notre store {type: "task/addTask", payload}
        // payload: est un objet contenant les paramètres de la fonction
        addTask : (state, action) => {
            const newTask = {
                text: action.payload,
                id: Date.now(),
                done: false
            }

            state.tasks.push(newTask)
            state.counterTask += 1
        },
        deleteTask : (state, action) => {
            state.tasks = state.tasks.filter((task) => task.id != action.payload)
            state.counterTask -= 1
        },
        toggleTask : (state, action) => {
            const task = state.tasks.find((taskItem) => taskItem.id == action.payload)
            task.done = !task.done

            if (task.done) {
                state.counterTask -= 1
            } else {
                state.counterTask += 1
            }
        }
    }
})

export const {addTask, deleteTask, toggleTask} = taskSlice.actions
export default taskSlice.reducer