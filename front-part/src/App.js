import React from 'react';
import './App.css';
import HeroInput from './Components/HeroInput';
import HeroUpdate from './Components/HeroUpdate';
import HeroGetById from './Components/HeroGetById';
import 'bootstrap/dist/css/bootstrap.min.css';
import {Row,Col} from 'react-bootstrap'

function App() {
	return (
	<div className="App">
		<header >

		</header>
			<div >
				<Row>
					<Col sm="3">    
						<HeroInput/>
						<HeroGetById/>
					</Col >
						<HeroUpdate/>

				</Row>
			</div>

	</div>
		);
	}

	export default App;
