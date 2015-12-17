import React from 'react'
import classnames from "classnames";

export default class TabMenu extends React.Component
{
	constructor(props)
	{
		super(props);
	}

	renderTabPanel(){
		console.log(this)
		for(let child in this.props.children){
			if(child == this.props.index){
				return this.props.children[child];
			}
		}
	}

	render(){
		return <div className="panel">{this.renderTabPanel()}</div>
	}
}