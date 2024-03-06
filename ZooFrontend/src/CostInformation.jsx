import './CostInformation.css'

function CostInformation({cost, meatCost, fruitCost}) {

  return (
    <>
      <section className='costInfo'>
        <h1>Zoo Feeding App</h1>
        <h3>Current Cost of feeding the animals:</h3>
        <h1>${cost} per day.</h1>
        <h3>Cost by food source:</h3>
        <h2>Meat: ${meatCost}, Fruit ${fruitCost}</h2>
      </section>
    </>
  )
}

export default CostInformation