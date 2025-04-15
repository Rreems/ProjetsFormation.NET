import { useRef } from "react";

const LoginForm = ({logUserInfos}) => {
    const username = useRef()
    const password = useRef()

    const submitForm = (e) => {
        e.preventDefault()
        logUserInfos(username.current.value, password.current.value)
        username.current.value = ""
        password.current.value = ""
    }


    return ( 
        <form onSubmit={submitForm}>
            <div>
                <label htmlFor="username">Username</label>
                <input type="text" ref={username} />
            </div>
            <div>
                <label htmlFor="password">Password</label>
                <input type="password" ref={password} />
            </div>
            <button type="submit">Valider</button>
        </form>
     );
}
 
export default LoginForm;