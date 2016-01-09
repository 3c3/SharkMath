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
		this.setState({selectedIndex: i})
		if(this.props.onChange != null){
			this.props.onChange(i)
		}
	}

	renderTabs(){
		if(!this.props.tabs){return <div></div>}
		//console.log(this.props)
		return this.props.tabs.map((t,i) => {return <span key={t+i} onClick={this.onChange.bind(this,i)} className={classnames({ selected: i == this.state.selectedIndex })}>{t}</span>})
	}

	render(){
		return(<nav {...this.props}>
				{(this.props.heading != null) ? <b>{this.props.heading}</b> : ""}
				{this.renderTabs()}
			</nav>)
	}
}