import './Individual.css'

function Individual({animal}) {

  return (
    <>
      <card className='animalCard'>
        <h3>{animal.name}</h3>
        <p>Species: {animal.species}</p>
        <p>Feeding Cost: ${animal.cost}</p>
      </card>
    </>
  )
}

export default Individual