import React from 'react';
import ReactDOM from 'react-dom';
import Katex from "./katex";
import lodash from "lodash"; //because I can
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
				<TabPanel heading="Генерирай:">
					<SingleProblem title="Eдна задача" />
					<MultipleProblems title="Mного задачи" />
				</TabPanel>
			</div>
			)
	}
}

document.addEventListener("DOMContentLoaded", function (event) {
	ReactDOM.render(<App/>, document.getElementById("app"));
});

