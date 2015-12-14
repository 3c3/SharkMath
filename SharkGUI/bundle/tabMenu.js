import React from 'react'
import classnames from "classnames";

export default class TabMenu extends React.Component
{
	constructor(props)
	{
		super(props);
		this.state = {
			selectedIndex: 0
		}
	}

	onChange(i,e){
		this.props.onChange(i)
		this.setState({selectedIndex: i})
	}

	renderTabs(){
		return this.props.tabs.map((t,i) => {return <span onClick={this.onChange.bind(this,i)} className={classnames({ show: i == this.state.selectedIndex })}>{t}</span>})
	}

	render(){
		return(<nav>
				{(this.props.heading != null) ? <b>{this.props.heading}</b> : ""}
				{this.renderTabs()}
			</nav>)
	}
}