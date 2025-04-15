import { useSelector } from "react-redux";

const TaskHeader = () => {
    const counter = useSelector(state => state.task.counterTask)

    return ( 
        <header>
            <h1>React todo list</h1>
            <p>Tâches à faire : <strong>{counter}</strong></p>
        </header>
     );
}
 
export default TaskHeader;