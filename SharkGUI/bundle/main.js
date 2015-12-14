import React from 'react';
import ReactDOM from 'react-dom';
import Katex from "./katex";
import validate from "validate.js"
import TypeList from "./typeList.js"
import lodash from "lodash"; //because I can
import TabMenu from "./tabMenu.js";

require("./style/katex.min.css");
require("./style/main.css");

class App extends React.Component
{
	constructor(props){
		super(props)
		this.state = {
			res: app.generate(),
			a: "",
			b: ""
		}
	}

	handleChange(key, constraints){
		if(!constraints){
			constraints = {}
		}
		return e => {
			var error = validate.single(e.target.value, constraints)
			if(error != undefined){
				alert(error[0]);
			}else{
				var state = {}
				state[key] = e.target.value;
				this.setState(state)
			}
		}
	}

	render(){
		return(
			<div className="tabs">
				<TabMenu onChange={(i,e) => console.log(i,e)} heading="Генерирай:" tabs={["много задачи", "една задача"]}></TabMenu>
				<div className="grid">
					<div className="collumn_side">
					Types
					<TypeList title="7kl">
						Hello world from 7kl
					</TypeList>
					<TypeList title="8kl">
						Hello world from 8kl

					</TypeList>

					</div>
					<div className="collumn_main">
						Math: 
						<input onChange={this.handleChange("a")}/>+
						<input onChange={this.handleChange("b")}/>
						<input value="Add" type="button" onClick={(e => this.setState({res: app.add(this.state.a, this.state.b)})).bind(this)} />
						<Katex problem={this.state.res} style={{fontSize: "1.5em"}}/>
					</div>
					<div className="collumn_side">
					Properties

					</div>
				</div>
			</div>
			)
	}
}

document.addEventListener("DOMContentLoaded", function (event) {
	ReactDOM.render(<App/>, document.getElementById("app"));
});

