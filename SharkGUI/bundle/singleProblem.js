import React from 'react'
import classnames from "classnames";
import validate from "validate.js"
import Katex from "./katex";

import Input from "./input";
import Range from "./range";

import SettingsPanel from "./settingsPanel";
import TabMenu from "./tabMenu.js";


export default class SingleProblem extends React.Component
{
	constructor(props)
	{
		super(props);
		this.state = {
			descriptor: {},
			problem: " - ",
			solution: " - "
		}

		window.test = (() => {
			console.log(app.test(this.state));
		}).bind(this)

	}

	generate(e){
		//alert("Hello");
		let res = app.generate(this.state.descriptor);
		console.log(res);

		this.setState({problem: res.problem, solution: res.solution});
	}



	render(){

		return(<div className="single">
						<div className="problem_display">
							<Katex problem={this.state.problem}/>
						</div>
						<div className="solution_display">
							<Katex problem={this.state.solution}/>

						</div>
						<span className="line" />
						<div className="content">
							<TabMenu className="type_choise_panel" tabs={["тъждествени изрази","уравнения","неравенства"]}/>


							<SettingsPanel onValue={val => {this.setState({descriptor: val})}}>
								<Input type="text" value="letter" label="Знак:" />

								<Range min={0} max={100} value="pFractions" label="pFractions"/>
								<Range min={0} max={100} value="pIrrational" label="pIrrational"/>

								<Input type="int" value="minTransformations" label="(min) Трансформаций:" />
								<Input type="int" value="maxTransformations" label="(max) Трансформаций:" />

								<Input type="int" value="power" label="Степен:" />
								<Input type="int" value="maxVisualPower" label="Видима степен" />
							</SettingsPanel>
						</div>
						<div className="button_bar">
							<div className="row">
								<input type="button" className="button button-grey" value="Отговори" />
								<input type="button" className="button button-blue" value="Генерирай" onClick={this.generate.bind(this)}/>
							</div>
						</div>

					</div>)
	}
}