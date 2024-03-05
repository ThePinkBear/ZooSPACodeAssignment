
function CostInformation({cost, meatCost, fruitCost}) {

  return (
    <>
      <h2>Zoo Feeding App</h2>
      <h3>Current Cost of feeding the animals:</h3>
      <h2>${cost} per day.</h2>
      <h3>Cost by food source:</h3>
      <h3>Meat: ${meatCost}, Fruit ${fruitCost}</h3>
    </>
  )
}

export default CostInformation