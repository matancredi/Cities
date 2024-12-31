import Navbar from 'react-bootstrap/Navbar';
import { useState, useEffect } from 'react'
import { Table } from 'react-bootstrap';

function ListCities() {
    const [cities, setCities] = useState([])
    const [states, setStates] = useState([])

    useEffect(() => {
        fetch(`city`, {
            method: 'get',
            //headers: {
            //    'Authorization': 'bearer ' + localStorage.getItem('password')
            //}
        })
            .then(res => res.json())
            .then(data => {
                setCities(data)
            })
            .catch(err => console.error(err, 'No cities in database'))
    }, [])

    useEffect(() => {
        fetch(`state`, {
            method: 'get',
            //headers: {
            //    'Authorization': 'bearer ' + localStorage.getItem('password')
            //}
        })
            .then(res => res.json())
            .then(data => {
                setStates(data)
            })
            .catch(err => console.error(err, 'No states in database'))
    }, [])

    const deleteCity = (id) => {
        fetch(`city?cityID=` + id, {
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
            },
            method: 'delete',
        });
        window.location.reload();
    }

    const searchStateName = (id) => {
        if (states.length > 0) {
            const state = states.find(s => s.id == id);
            return state.name;
        }
        
    }

    return (
        <div>
            <Navbar></Navbar>
            <h2 style={{ padding: '10px' }}>Cities</h2>
            {cities.length === 0 ? <span>No cities registered</span> :
                <Table striped="columns" bordered hover variant="dark">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>State</th>
                            <th>Creation Date</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {cities.map(city =>
                            <tr key={city.id}>
                                <td>{city.name}</td>
                                <td>{searchStateName(city.stateID)}</td>
                                <td>{new Date(city.creationDate).toLocaleString('en-US')}</td>
                                <td><button onClick={() => deleteCity(city.id)}>Delete</button></td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            }
        </div>
    );
}

export default ListCities;
