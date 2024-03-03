import './App.css'
import { useEffect, useState } from 'react'

function App() {

  const [animals, setAnimals] = useState([])
  const [cost, setCost] = useState(0)

  useEffect(() => {
    fetch('http://localhost:5068/ZooAnimals')
      .then((response) => response.json())
      .then((data) => setAnimals(data))

    fetch('http://localhost:5068/ZooPrices')
      .then((response) => response.json())
      .then((data) => setCost(data))
  },[]);

  return (
    <>
      <h2>Current Cost of the Zoo animals:</h2>
      <h1>{cost}</h1>
      <ul>
        {animals.map((animal) => (
          <li key={animal.id}>{animal.name}</li>
        ))}
      </ul>
    </>
  )
}

export default App
