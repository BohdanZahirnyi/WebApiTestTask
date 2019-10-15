import React from 'react';
import axios from "axios";
import { Col, FormControl, InputGroup, Form, Button } from 'react-bootstrap'

export default class HeroInput extends React.Component {
    state = {
        name: '',
    };

    handleChange = event => {
        this.setState({ name: event.target.value });
    };
    handleSubmit = event => {
        event.preventDefault();
        const hero = {
            name: this.state.name
        }
        const name = hero.name;
        axios.post('http://localhost:64409/api/heroes/upsert', { name })
            .then(res => {
                console.log(res);
                console.log(res.data);
                window.location.reload();
            });
    };
    render() {


        return (
            <Col sm="2">
                <Form style={{ width: 300, margin: '1px', border: '2px solid rgba(255, 0, 0, 0.4	)', padding: '10px', borderRadius: '10px' }} onSubmit={this.handleSubmit}>
                    <Form.Label>New hero:</Form.Label>
                    <InputGroup className="mb-3">
                        <FormControl type="text" name="name" placeholder="Enter your hero name..." onChange={this.handleChange} />
                        <InputGroup.Append>
                            <Button variant="primary" type="submit">Add hero</Button>
                        </InputGroup.Append>
                    </InputGroup>
                </Form>
            </Col>
        );

    }
}
