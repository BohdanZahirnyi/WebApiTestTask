import React from 'react';
import axios from "axios";
import { Col, FormControl, Form, Button } from 'react-bootstrap'


export default class HeroUpdate extends React.Component {
    state = {
        name: '',
        id: 0
    };

    handleChangeName = event => {
        this.setState({ name: event.target.value });
    };
    handleChangeId = event => {
        this.setState({ id: event.target.value });
    };
    handleSubmit = event => {
        event.preventDefault();
        const hero = {
            name: this.state.name,
            id: this.state.id
        }
        const id = hero.id;
        const name = hero.name;
        axios.put(`http://localhost:64409/api/heroes/upsert/${id}`, { id, name })
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


                    <Form.Group>
                        <Form.Label>Enter new hero name:</Form.Label>
                        <FormControl type="text" name="name" onChange={this.handleChangeName} />
                    </Form.Group>
                    <Form.Group>
                        <Form.Label>Enter hero id:</Form.Label>
                        <FormControl type="number" name="id" onChange={this.handleChangeId} />

                    </Form.Group>
                    <Button type="submit" variant="warning">Update</Button>


                </Form>
            </Col>
        );

    }
}
