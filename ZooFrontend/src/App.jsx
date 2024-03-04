import './App.css'
import { useEffect, useState } from 'react'
import Individual from './Individual'

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
      <h2>Zoo Feeding App</h2>
      <h3>Current Cost of feeding the animals:</h3>
      <h2>${cost} per day.</h2>
      <section>
        {animals.map(animal => (
          <Individual key={animal.id} animal={animal}/>
        ))}
      </section>
    </>
  )
}

export default App
