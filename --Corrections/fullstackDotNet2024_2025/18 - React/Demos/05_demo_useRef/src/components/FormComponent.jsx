const FormComponent = () => {
      // const firstname = useRef()
  // const lastname = useRef()

  // const getValueFromInput = (e) => {
  //   e.preventDefault()
  //   console.log(firstname.current.value);
  //   console.log(lastname.current.value);
  //   firstname.current.value = ""
  //   lastname.current.value = ""
  // }

  // Version 19

  const getValueFromInput = (formData) => {
    console.log(formData.get("firstname"));
    console.log(formData.get("lastname"));
  }
    return ( 
        <>
            {/* <form onSubmit={getValueFromInput}>
                <div>
                    <label htmlFor="firstname">Firstname</label>
                    <input type="text" ref={firstname} />
                </div>
                <div>
                    <label htmlFor="lastname">Lastname</label>
                    <input type="text" ref={lastname} />
                </div>
                <button type='submit'>Valider</button>
            </form> */}

            {/* Version 19 */}
            <form action={getValueFromInput}>
                <div>
                <label htmlFor="firstname">Firstname</label>
                <input type="text" name='firstname' />
                </div>
                <div>
                <label htmlFor="lastname">Lastname</label>
                <input type="text" name='lastname' />
                </div>
                <button type='submit'>Valider</button>
            </form>
        </>
     );
}
 
export default FormComponent;