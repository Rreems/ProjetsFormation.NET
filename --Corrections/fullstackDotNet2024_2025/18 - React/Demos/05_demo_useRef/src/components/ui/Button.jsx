const Button = ({children, ...props}) => {
    return ( 
        <button className='btn btn-success' {...props}>{children}</button>
     );
}
 
export default Button;