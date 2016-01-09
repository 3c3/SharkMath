import React from 'react'


export default class Input extends React.Component
{
	onChange(e){
		//var val = e.target.value | 0;
		if(this.props.type == "text"){
			this.props.onChange(e.target.value);
		}else if(this.props.type == "int"){
			this.props.onChange(e.target.value | 0);
		}
	}

	render(){
		return <div className="input"><span className="label">{this.props.label}:</span><input type="text" defaultValue={this.props.def} min={this.props.min} max={this.props.max} onChange={this.onChange.bind(this)}/></div>
	}
}