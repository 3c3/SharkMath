import katex from 'katex';
import React from 'react'

class Katex extends React.Component
{
	constructor(props)
	{
		super(props);
	}

	render(){
		return(<span id={this.props.id} style={this.props.style} className="latex" ref="content" dangerouslySetInnerHTML={{__html: katex.renderToString(this.props.problem)}}></span>)
	}
}

export default Katex;