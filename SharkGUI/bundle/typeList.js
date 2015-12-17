import React from 'react';
import classnames from "classnames";
require("./style/typeList.css");

export default class TypeList extends React.Component
{
	constructor(props){
		super(props)
		this.state = {
			show: false
		}
	}

	buttonClick(event){
		if(this.state.show){
			this.setState({show: false})
		}else{
			this.setState({show: true})
		}
	}

	render(){
		return(
			<div className="drop_menu">
				<div className="bar">
				<span className="title">{this.props.title}</span>
				<span className="bar_button" onClick={this.buttonClick.bind(this)}>{(this.state.show) ? "/\\" : "V"}</span>
				</div>

				<div className={classnames({ panel: true }, { panel_show: this.state.show },  { panel_hide: !this.state.show })}>
					{this.props.children}
				</div>
			</div>)
	}
}