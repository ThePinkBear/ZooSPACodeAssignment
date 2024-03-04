
function CostInformation({cost, meatCost, fruitCost}) {

  return (
    <>
      <h2>Zoo Feeding App</h2>
      <h3>Current Cost of feeding the animals:</h3>
      <h2>${cost} per day.</h2>
      <h3>Cost of feeding the animals:</h3>
      <h3>${meatCost} on meat, ${fruitCost} on fruit</h3>
    </>
  )
}

export default CostInformation