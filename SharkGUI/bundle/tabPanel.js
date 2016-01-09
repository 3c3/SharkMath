import React from 'react'
import classnames from "classnames";

export default class TabMenu extends React.Component
{
	constructor(props)
	{
		super(props);
		this.state = {
			index: 0,
			tabs: []
		}
	}

	renderTabPanel(){
		console.log(this)
		let children = React.Children.toArray(this.props.children);
		let titles = []
		
		for(let child in children){
			if(child == this.props.index){
				title.append(this.props.children[child].title);
				return this.props.children[child];
			}
		}
		this.setState({tabs: titles});
	}

	render(){
		return 	<div className="panel">
					<TabMenu onChange={i => this.setState({index: i})} heading={this.props.heading} tabs={this.state.tabs}></TabMenu>
					{this.renderTabPanel()}
				</div>
	}
}