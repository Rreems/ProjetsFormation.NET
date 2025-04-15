import { useSelector } from "react-redux";
import TaskItem from "./TaskItem";

const TaskList = () => {
    const tasks = useSelector(state => state.task.tasks)

    return ( 
        <>
            {
                tasks.map((task) => (
                    <TaskItem task={task} key={task.id} />
                ))
            }
        </>
     );
}
 
export default TaskList;