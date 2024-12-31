//using html
export default function SaveCity() {
    async function saveCity(event) {
        event.preventDefault();
        
        let cityName = document.getElementById("cityName").value;
        let stateID = document.getElementById("stateID").value;
        let city = {
            "name": cityName,
            "stateID": stateID,
            "CreationDate": new Date()
        };
        fetch(`city`, {
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
                'Access-Control-Allow-Origin': '*'
            },
            method: 'post',
            body: JSON.stringify(city),
        })
            .then(res => res.json())
            .then(res => {
                if (res.status === 400)
                    alert('Error')
                else
                    alert(res)
            })
    }
    return (
        <form method="post" onSubmit={saveCity}>
            <input label="City name" type="text" name="cityName" id="cityName" />
            <br></br>
            <input label="State ID" type="text" name="stateID" id="stateID" />
            <br></br>
            <button type="submit" value="submit" >Save</button>
        </form>
    );
}
