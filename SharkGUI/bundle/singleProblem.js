import React from 'react'
import classnames from "classnames";
import validate from "validate.js"
import Katex from "./katex";
import Range from "./range";

/*
var interop = {
	letter: '',					//char letter;
	pFractions: 0,				//byte pFractions;
	pIrrational: 0,				//byte pIrrational;
	minTransformations: 0,		//byte minTransformations;
	maxTransformations: 2,		//byte maxTransformations;
	power: 1,					//byte power
	maxVisualPower: 2			//byte maxVisualPower;
}
*/

export default class SingleProblem extends React.Component
{
	constructor(props)
	{
		super(props);
		this.state = {
			letter: '',					//char letter;
			pFractions: 0,				//byte pFractions;
			pIrrational: 0,				//byte pIrrational;
			minTransformations: 0,		//byte minTransformations;
			maxTransformations: 2,		//byte maxTransformations;
			power: 1,					//byte power
			maxVisualPower: 2			//byte maxVisualPower;
		}

		window.test = (() => {
			console.log(app.test(this.state));
		}).bind(this)

	}

	generate(e){
		alert("Hello");
		alert(app.generate(this.state));
	}

	hcex(key, event, constraints){ // the not so good way but my way http://www.osnews.com/images/comics/wtfm.jpg
		var stringFunction = "e => {\nvar ";
		if(event){
			stringFunction += "res = e.target.value;"
		}else{
			stringFunction += "res = e;"
		}

		var res = "";
		if(isNaN(this.state[key])){
			res += "res";
		}else{
			res += "res | 0";

		}

		var assign = `
			var state = {};
			state["${key}"] = ${res};
			this.setState(state);
			console.log(this.state);
		`

		if(constraints){
			stringFunction += `
			if(error != undefined){
				alert(error[0]);
			}else{ ${assign} }`
		}else{
			stringFunction += assign;
		}
		stringFunction += "}";
		return eval(stringFunction).bind(this);

	}
	// the proper way but not my way.
	handleChange(key, constraints){
		if(!constraints){
			return e => {
				var state = {}
				state[key] = e.target.value;
				this.setState(state)
			}
		}

		/*if(key.constructor === Array){ // Бял код за черни дни
			return e => {
				for(var k in key){
					state[key][k] = res[k];
				}
			}
		}*/

		return e => {
			let res ;
			if(!e.target){
				res = e;
			}else{
				res = e.target.value
			}
			var error = validate.single(res, constraints)
			if(error != undefined){
				alert(error[0]);
			}else{
				var state = {}
				state[key] = res;
				this.setState(state)
			}
		}
	}


	render(){
		return(<div className="single">
						<div className="problem_display">
							<Katex problem={"x^2+5x-6"}/>
						</div>
						<div className="solution_display">
							<Katex problem={"x_1=1, x_2=-6"}/>

						</div>
						<span className="line" />
						<div className="content">
							<div className="type_choise_panel">
								<span>тъждествени изрази</span>
								<span className="selected">уравнения</span>
								<span>неравенства</span>
							</div>

							<div className="settings_panel">
								Настройки:
								<div className="input"><span className="label">Знак:</span><input type="text" onChange={this.hcex("letter",true)} /></div>

								<Range min={0} max={100} onChange={this.hcex("pFractions")} label="pFractions"/>
								<Range min={0} max={100} onChange={this.hcex("pIrrational")} label="pIrrational"/>


								<div className="input"><span className="label">(min) Трансформаций:</span><input type="text" onChange={this.hcex("minTransformations",true)} /></div>
								<div className="input"><span className="label">(max) Трансформаций:</span><input type="text" onChange={this.hcex("maxTransformations",true)} /></div>

								<div className="input"><span className="label">Степен:</span><input type="text" onChange={this.hcex("power",true)} /></div>
								<div className="input"><span className="label">Видима степен:</span><input type="text" onChange={this.hcex("maxVisualPower",true)} /></div>


							</div>
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