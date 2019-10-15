import React from 'react';
import axios from "axios";
import Hero from './Hero';
import { Col, FormControl, InputGroup, Form, Button } from 'react-bootstrap'

export default class HeroGetById extends React.Component {
    state = {
        heroes: [],
        id: 0
    };

    handleChange = event => {
        this.setState({ id: event.target.value });
    };

    handleSubmit = event => {
        event.preventDefault();
        const hero = {
            id: this.state.id
        }
        const id = hero.id;
        axios.get(`http://localhost:64409/api/heroes/get/${id}`, { id })
            .then(res => {
                console.log(res);
                this.setState({ heroes: res.data });
                //window.location.reload();

            });
    };

    componentDidMount() {

        const hero = {
            id: this.state.id
        }
        const id = hero.id;
        axios.get(`http://localhost:64409/api/heroes/get/${id}`, { id })
            .then(res => {
                console.log(res);
                this.setState({ heroes: res.data });
                //window.location.reload();

            });
    }
    render() {

        return (
            <Col sm="3">
                <div>
                    <Form style={{ width: 300, margin: '1px', border: '2px solid rgba(255, 0, 0, 0.4	)', padding: '10px', borderRadius: '10px' }} onSubmit={this.handleSubmit}>
                        <Form.Label>Find by Id:</Form.Label>

                        <InputGroup className="mb-3">
                            <FormControl type="text" name="name" placeholder="Enter id..." onChange={this.handleChange} />
                            <InputGroup.Append>
                                <Button variant="primary" type="submit">Find</Button>
                            </InputGroup.Append>
                        </InputGroup>

                    </Form>

                    <Hero data={this.state.heroes} />
                </div>

            </Col>
        );

    }
}
