const Button = ({children, ...props}) => {
    // Version 19 
    const {pending} = useFormStatus()
    return ( 
        <button className='btn btn-success' {...props}>{pending ? "Chargement..." : children}</button>
     );
}
 
export default Button;