import { useDispatch } from "react-redux";
import { deleteTask, toggleTask } from "./TaskSlice";

const TaskItem = ({task}) => {
    const dispatch = useDispatch()

    return ( 
        <div>
            <label>
                <input type="checkbox" 
                checked={task.done}
                onChange={() => dispatch(toggleTask(task.id))} 
                />
                {task.text}
            </label>
            <span
                onClick={() => dispatch(deleteTask(task.id))}
                role="button"
                style={{ padding: "5px", marginLeft: "20px" }}
            >
                X
            </span>
        </div>
     );
}
 
export default TaskItem;