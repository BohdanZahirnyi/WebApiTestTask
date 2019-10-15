import React from 'react';
import axios from "axios";

export default class HeroList extends React.Component
{
	state = {
		heroes: [],
	};
	
	componentDidMount()
	{
		axios.get('http://localhost:64409/api/heroes').then(res => 
		{
			console.log(res);
			this.setState({heroes: res.data});
		})
	}
	render()
	{
		 
		
			return
			 <ul>
			{this.state.heroes.map(hero => 
				<li key={hero.id}> {hero.id} {hero.name}</li>
				)}	
			</ul>

		
	}
}
