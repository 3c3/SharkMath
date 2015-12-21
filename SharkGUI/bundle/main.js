import React from 'react';
import ReactDOM from 'react-dom';
import Katex from "./katex";
import lodash from "lodash"; //because I can
import TabMenu from "./tabMenu.js";
import TabPanel from "./tabPanel.js";

import SingleProblem from "./singleProblem.js";
import MultipleProblems from "./multipleProblem.js";


require("./style/katex.min.css");
require("./style/main.css");

class App extends React.Component
{
	constructor(props){
		super(props)
		this.state = {
			index: 0
		}
	}

	render(){
		return(
			<div className="tabs app">
				<TabMenu onClick={e => console.log("Hello")} onChange={i => this.setState({index: i})} heading="Генерирай:" tabs={["Eдна задача", "Mного задачи"]}></TabMenu>
				<TabPanel index={this.state.index}>
					<SingleProblem />
					<MultipleProblems />

					
				</TabPanel>
			</div>
			)
	}
}

document.addEventListener("DOMContentLoaded", function (event) {
	ReactDOM.render(<App/>, document.getElementById("app"));
});

