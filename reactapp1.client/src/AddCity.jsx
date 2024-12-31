import { Card, Alert } from 'react-bootstrap';
import { useState, useEffect } from 'react'

function AddCity() {
    const [cityName, setCityName] = useState("")
    const [stateID, setStateID] = useState('')
    const [message, setMessage] = useState('')
    const [states, setStates] = useState([])

    const handle = () => {
        let values = {
            "name": cityName,
            "stateID": stateID,
            "CreationDate": new Date()
        }
        addCity(values);
    }

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

    const addCity = (values) => {
        fetch(`city`, {
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
                'Access-Control-Allow-Origin': '*'
            },
            method: 'post',
            body: JSON.stringify(values),
        })
            .then(res => res.json())
            .then(res => {
                if (res.status === 400 || res.status === 500)
                    setMessage('Error')
                else
                    setMessage(res)
            })
        window.location.reload();
    }

    return (
        <>
            {message !== '' ? <Alert variant={'primary'}> {message} </Alert> : null}
            <Card style={{ width: "50%"}}>
                <h2 style={{ padding: '10px' }}>Add new city</h2>
                <Card.Body>
                    <input
                        type="text"
                        placeholder="Type city name"
                        onChange={e => setCityName(e.target.value)}
                    />
                    <br></br>
                    {/*<input*/}
                    {/*    type="text"*/}
                    {/*    placeholder="Type state ID"*/}
                    {/*    onChange={e => setStateID(e.target.value)}*/}
                    {/*/>*/}
                        <select  onChange={e => setStateID(e.target.value)} >
                            <option value=""></option>
                            {states.length > 0 ? states.map((p) => (
                                <option key={p.id} value={p.id}>{p.name}</option>
                            )) : null}
                        </select>
                    <br></br>
                    <br></br>
                    <button onClick={() => handle("addCity")}>Cadastrar</button>
                </Card.Body>
            </Card>
        </>
    );
}

export default AddCity;
