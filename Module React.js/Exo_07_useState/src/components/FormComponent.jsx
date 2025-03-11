import { useRef } from "react";

const FormComponent = ({onConnection}) => {

    
    const login = useRef()
    const password = useRef()

    const getValueFromInput = (e) => {
        e.preventDefault()

        onConnection(login.current.value, password.current.value);

        // login.current.value= "";
        password.current.value= "";
      }

    return (
        <>
            <form onSubmit={getValueFromInput}>
                <div>
                <label htmlFor="login">Login</label>
                <input type="text" ref={login} />
                </div>

                <div>
                <label htmlFor="password">Password</label>
                <input type="password" ref={password} />
                </div>
                <button type='submit'>Valider</button>
            </form>

        </>
    );
}

export default FormComponent;