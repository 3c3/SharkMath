import React from 'react'


export default class Range extends React.Component
{
	onChange(e){
		//var val = e.target.value | 0;
		this.props.onChange(e.target.value | 0);
	}

	render(){
		return <div className="input"><span className="label">{this.props.label}:</span><input type="range" defaultValue={this.props.def} onChange={this.onChange.bind(this)}/></div>
	}
}