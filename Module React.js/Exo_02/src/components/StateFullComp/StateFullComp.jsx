import { PureComponent } from "react";

class StateFullComp extends PureComponent {
    constructor(props) {
        super(props);

        this.state = {
            prenom: "bob",
            age: 20
        }
    }

    changerAge(){
        this.setState(previousState => ({...previousState, age: previousState.age+1}))
    }

    render() {
        return (
            <>
                <h1>Statefull Componants</h1>
                <p>{this.state.prenom} - {this.state.age}</p>

                <button onClick={this.changerAge.bind(this)}>Anniversaire 🎂 !!</button>
            </>
        );
    }
}

export default StateFullComp;