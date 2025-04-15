const ChildComponent = ({paramA, paramB, parentFunction}) => {
    // console.log(props);

    const sayHello = () => {
        console.log("Hello world");
        parentFunction()
    }

    return ( <>
    <h1>ChildComponent</h1>
    <p>{paramA}</p>
    <button onClick={() => parentFunction()} >Valider</button>
    </> );
}
 
export default ChildComponent;