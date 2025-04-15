import { PureComponent } from "react";

class StateFullComponent extends PureComponent {
    constructor(props) {
        super(props);
        this.state = {
            monPrenom : "toto",
            age: 20
        }
    }

    changerPrenom() {
        this.setState(previousState => ({...previousState, monPrenom: "Titi"}))
    }
  
    render() { 
        return ( 
            <>
                <h1>StateFullComponent</h1>
                <p>{this.state.monPrenom} - {this.state.age} ans</p>
                <button onClick={this.changerPrenom.bind(this)}>changerPrenom</button>
            </>
         );
    }
}
 
export default StateFullComponent;