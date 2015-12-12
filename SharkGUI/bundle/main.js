import React from 'react';
import ReactDOM from 'react-dom';
import Katex from "./katex";

require("./katex.min.css");

class App extends React.Component
{
	constructor(props){
		super(props)
		this.state = {
			res: app.generate()
		}
	}


	render(){
		return(
			<div>
				Math: 
				<input onChange={((e) => {this.setState({a: e.target.value})}).bind(this)}/>+
				<input onChange={((e) => {this.setState({b: e.target.value})}).bind(this)}/>
				<input value="Add" type="button" onClick={(e => this.setState({res: app.add(this.state.a, this.state.b)})).bind(this)} />
				<Katex problem={this.state.res}/>
			</div>)
	}
}
window.render = () => {
	ReactDOM.render(<App/>, document.getElementById("app"));
}

