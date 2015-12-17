import React from 'react';
import ReactDOM from 'react-dom';
import Katex from "./katex";
import validate from "validate.js"
import TypeList from "./typeList.js"
import lodash from "lodash"; //because I can
import TabMenu from "./tabMenu.js";
import TabPanel from "./tabPanel.js";


require("./style/katex.min.css");
require("./style/main.css");

class App extends React.Component
{
	constructor(props){
		super(props)
		this.state = {
			res: app.generate(),
			index: 0,
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
			<div className="tabs app">
				<TabMenu onChange={i => this.setState({index: i})} heading="Генерирай:" tabs={["Eдна задача", "Mного задачи"]}></TabMenu>
				<TabPanel index={this.state.index}>
					<div className="single">
						<div className="problem_display">
							<Katex problem={"x^2+5x-6"}/>
						</div>
						<div className="solution_display">
							<Katex problem={"x_1=1, x_2=-6"}/>

						</div>
						<span className="line" />
						<div className="settings_panel">
						Настройки:

						</div>
						<div className="button_bar">
							<div className="row">
								<input type="button" className="button button-grey" value="Отговори"/>
								<input type="button" className="button button-blue" value="Генерирай"/>
							</div>
						</div>

					</div>

					<div className="multy">
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
						Мнго задачи
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
				</TabPanel>
			</div>
			)
	}
}

document.addEventListener("DOMContentLoaded", function (event) {
	ReactDOM.render(<App/>, document.getElementById("app"));
});

