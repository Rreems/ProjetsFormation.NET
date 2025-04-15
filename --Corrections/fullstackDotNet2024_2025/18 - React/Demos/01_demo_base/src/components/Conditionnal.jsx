import classes from "./Conditionnal.module.css"

const Conditionnal = () => {
    let age = 15
    let prenom = "Toto"
    let isTrue = false

    // if(age >= 18){
    //     return (
    //         <>
    //             <p>Bonjour, je suis {prenom} j'ai {age} ans</p>
    //         </>
    //     )
    // } {
    //     return (
    //         <>
    //             <p>Bonjour, j'ai moins de 18 ans</p>
    //         </>
    //     )
    // }

    return (
        <>
            <p className={isTrue ? classes.isTrue : classes.isFalse}>{age >= 18 ? `Bonjour, je suis ${prenom} j'ai ${age} ans` : "Bonjour, j'ai moins de 18 ans"}</p>
            {isTrue && <p>C'est vrai !</p>}
        </>
    )

}
 
export default Conditionnal;