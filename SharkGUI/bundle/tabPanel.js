import React from 'react'
import classnames from "classnames";
import TabMenu from "./tabMenu.js";

export default class TabPanel extends React.Component
{
	constructor(props)
	{
		super(props);
		this.state = {
			index: 0,
			tabs: []
		}
	}

	componentWillMount(){
		this.componentWillReceiveProps(this.props);
	}

	componentWillReceiveProps(newProps){
		let titles = []
		let children = React.Children.toArray(newProps.children);
		
		children.forEach(child => {
			titles.push(child.props.title);
		})
		
		this.setState({tabs: titles});

	}

	renderTabPanel(){
		let children = React.Children.toArray(this.props.children);
		
		for(let child in children){
			if(child == this.state.index){
				//console.log(this.props.children[child]);
				return this.props.children[child];
			}
		}
	}

	render(){
		return 	<div className="panel">
					<TabMenu onChange={i => this.setState({index: i})} heading={this.props.heading} tabs={this.state.tabs}></TabMenu>
					{this.renderTabPanel()}
				</div>
	}
}