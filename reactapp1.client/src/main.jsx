import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
//import App from './App.jsx'
//import SaveCity from './SaveCity.jsx'
import AddCity from './AddCity.jsx'
import ListCities from './ListCities.jsx'

createRoot(document.getElementById('root')).render(
    <StrictMode>
        <ListCities />
        <br/>
        <AddCity />
  </StrictMode>,
)
