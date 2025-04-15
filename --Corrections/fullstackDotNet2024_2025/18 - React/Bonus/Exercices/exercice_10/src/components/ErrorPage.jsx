import {useRouteError, Link} from "react-router-dom"

const ErrorPage = () => {
  const error = useRouteError()

  return ( 
    <>
      <h1>Error {error.status}</h1>
      <p>{error.data}</p>
      <Link to={"/"}>HomePage</Link>
    </>
   );
}
 
export default ErrorPage;