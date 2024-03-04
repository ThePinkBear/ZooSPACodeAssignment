import { Routes, Route, Link } from 'react-router-dom'
import { useEffect, useState } from 'react'
import Animals from './Animals'
import Navbar from './Navbar'
import CostInformation from './CostInformation'

function App() {
  const [animals, setAnimals] = useState([])
  const [cost, setCost] = useState(0)
  const [meatCost, setMeatCost] = useState(0)
  const [fruitCost, setFruitCost] = useState(0)

  useEffect(() => {
    fetch('http://localhost:5068/ZooAnimals')
      .then((response) => response.json())
      .then((data) => setAnimals(data))

    fetch('http://localhost:5068/ZooTotalCost')
      .then((response) => response.json())
      .then((data) => setCost(data))

    fetch('http://localhost:5068/ZooMeatCost')
      .then((response) => response.json())
      .then((data) => setMeatCost(data))

    fetch('http://localhost:5068/ZooFruitCost')
      .then((response) => response.json())
      .then((data) => setFruitCost(data))
  },[]);

  return (
  <>
    <header>
      <nav>
        <Navbar />
      </nav>
    </header>
    <main>
      <Routes>
        <Route>
          <Route path="/" element={<CostInformation cost={cost} meatCost={meatCost} fruitCost={fruitCost} />} />
          <Route path="/animals" element={<Animals animals={animals} />} />
        </Route>
      </Routes>
    </main>
  </>
  )
}

export default App
