import React from 'react'
import classnames from "classnames";
import validate from "validate.js"
import Katex from "./katex";
import TypeList from "./typeList.js"

export default class MultipleProblems extends React.Component
{
	constructor(props){
		super(props)
		this.state = {
			a: "",
			b: ""
		}

		
	}

	handleChange(key, constraints){
		if(!constraints){
			return e => {
				var state = {}
				state[key] = e.target.value;
				this.setState(state)
			}
		}

		if(key.constructor === Array){
			return e => {
				for(var b in r){
					alert(r[b])
				}
			}
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
		return(<div className="multy">
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
					</div>)
	}
}