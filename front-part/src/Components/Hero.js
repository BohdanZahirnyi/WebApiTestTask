import React from 'react';
import Table from 'react-bootstrap/Table'
import Button from 'react-bootstrap/Button';
import axios from "axios";

class Hero extends React.Component {

    handleDeleteSubmit = (id) => {
        axios.delete(`http://localhost:64409/api/heroes/delete/${id}`)
            .then(res => {
                console.log(res);
                window.location.reload();

            });
    };
    render() {
        const heroes = this.props.data;
        console.log(heroes);

        return (
            <div>
                <Table>

                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Delete</th>
                        </tr>
                    </thead>
                    <tbody>
                        {heroes.map(hero =>
                            <tr>
                                <td>{hero.id}</td>
                                <td>{hero.name}</td>
                                <td><Button style={{ margin: '1px' }} type="submit" variant="danger" onClick={() => this.handleDeleteSubmit(hero.id)}>Delete</Button></td>
                            </tr>
                        )}
                    </tbody>
                </Table>

            </div>
        );
    };
}

export default Hero;



