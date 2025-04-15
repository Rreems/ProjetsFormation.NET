import axios from "axios"

const Login = () => {

    const login = () => {
        localStorage.setItem("token", "token")
    }

    const logout = () => {
        localStorage.removeItem("token")
    }

    return ( 
        <>
            <h1>Login</h1>
            <button onClick={() => login()}>Login</button>
            <button onClick={() => logout()}>Logout</button>
        </>
     );
}
 
export default Login;