import React from 'react'
import classnames from "classnames";
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

export default class SettingsPanel extends React.Component
{
	constructor(props)
	{
		super(props);
		this.state = {
			letter: "x",				//char letter;
			pFractions: 0,				//byte pFractions;
			pIrrational: 0,				//byte pIrrational;
			minTransformations: 0,		//byte minTransformations;
			maxTransformations: 2,		//byte maxTransformations;
			power: 1,					//byte power
			maxVisualPower: 2			//byte maxVisualPower;
		}
	}



	hcex(key, settings){ // the not so good way but my way http://www.osnews.com/images/comics/wtfm.jpg
		var stringFunction = "e => {\nvar ";
		if(settings.event){
			if(settings.event == true){
				stringFunction += "res = e.target.value;"
			}else{
				stringFunction += "res = e;"
			}	
		}else{
			stringFunction += "res = e;"
		}

		var res = "";
		if(settings.type){
			if(settings.type == "string"){
				res += "res";
			}else if(settings.type == "number"){
				res += "res | 0";
			}
		}else{
			res += "res | 0";
		}

		var assign = `
			var state = {};
			state["${key}"] = ${res};
			this.setState(state);
			console.log(this.state);
		`

		if(settings.constraints){
			stringFunction += `
			var error = validate.single(res, ${JSON.stringify(settings.constraints)})

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

		let set = (key, val) => {
			var state = {}
			state[key] = val
			this.setState(state, () => {
				this.props.onValue(this.state);
			})
		}

		let getValue = (e) => {
			let res;
		//	if(!e.target){
				res = e;
		//	}else{
		//		res = e.target.value
		//	}
			return res;
		}

		if(!constraints){
			return e => {
				var value = getValue(e);
				set(key, value);
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
			let value = getValue(e);
			var error = validate.single(value, constraints)
			if(error != undefined){
				alert(error[0]);
			}else{
				set(key, value);
			}
		}
	}

	renderTabPanel(){
		let hc = this.handleChange.bind(this);
		//console.log(this)
		return React.Children.map(this.props.children, child => {
		//	console.log(child)
			return React.cloneElement(child, { onChange: hc(child.props.value), def: this.state[child.props.value] });
		});
	}

	render(){
		return <div className="settings_panel">{this.renderTabPanel()}</div>
	}
}