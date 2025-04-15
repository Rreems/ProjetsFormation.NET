import ChildComponent from "./ChildComponent";

const ParentComponent = () => {
    let paramA = "paramA"
    let paramB = "paramB"

    const sayHelloFromParent= () => {
        console.log("Hello depuis le parent");
    }

    return ( 
        <>
            <ChildComponent paramA={paramA} paramB={paramB} parentFunction={sayHelloFromParent} />
        </>
     );
}
 
export default ParentComponent;