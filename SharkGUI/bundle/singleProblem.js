import React from 'react'
import classnames from "classnames";
import validate from "validate.js"
import Katex from "./katex";

import Input from "./input";
import Range from "./range";

import SettingsPanel from "./settingsPanel";
import TabMenu from "./tabMenu.js";

let types = [
	app.generateEquations,
	app.generateInequations
]

export default class SingleProblem extends React.Component
{
	constructor(props)
	{
		super(props);
		this.state = {
			descriptor: {},
			selectedType: 0,
			result: [{
				Problem: " - ",
				Solution: " - "
			}]
		}

		window.test = (() => {
			console.log(app.test(this.state));
		}).bind(this)

	}

	generate(e){
		//alert("Hello");
		console.log(types[this.state.selectedType], this.state.selectedType , types)
		let res = JSON.parse(types[this.state.selectedType](this.state.descriptor, 2));
		console.log("Result: ",res);

		this.setState({result: res});
	}



	render(){

		return(<div className="single">
						<div className="problem_display">
							<Katex problem={this.state.result[0].Problem}/>
						</div>
						<div className="solution_display">
							<Katex problem={this.state.result[0].Solution}/>

						</div>
						<span className="line" />
						<div className="content">
							<TabMenu onChange={e => {this.setState({selectedType: e})}} className="type_choise_panel" tabs={[/*"тъждествени изрази",*/"уравнения","неравенства"]}/>


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