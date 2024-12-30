import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [cities, setCities] = useState();

    useEffect(() => {
        populateCitiesData();
    }, []);

    const contents = cities === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Creation Date</th>
                </tr>
            </thead>
            <tbody>
                {cities.map(city =>
                    <tr key={city.id}>
                        <td>{city.name}</td>
                        <td>{city.creationDate}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tableLabel">Cities</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );
    
    async function populateCitiesData() {
        const response = await fetch('city');
        if (response.ok) {

            const data = await response.json();
            setCities(data);
        }
    }
}

export default App;