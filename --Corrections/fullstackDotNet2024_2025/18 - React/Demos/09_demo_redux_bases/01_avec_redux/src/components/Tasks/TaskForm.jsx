import { useDispatch } from "react-redux";
import { addTask } from "./TaskSlice";

const TaskForm = () => {
    const dispatch = useDispatch()

    const handleSubmit = (formData) => {
        dispatch(addTask(formData.get("text")))
    }
    return ( 
        <form action={handleSubmit}>
            <input type="text" name="text" placeholder="Ajouter une tâche" />
        </form>
     );
}
 
export default TaskForm;