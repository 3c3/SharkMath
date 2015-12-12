var React = require('react');
var ReactDOM = require('react-dom');

class App extends React.Component
{
	constructor(props){
		super(props)
	}

	render(){
		return(
			<div>
				Hello world
			</div>)
	}
}
window.render = () => {
	ReactDOM.render(<App/>, document.getElementById("app"));
}

