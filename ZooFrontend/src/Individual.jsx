import './Individual.css'

function Individual({animal}) {

  return (
    <>
      <article className='animalCard'>
        <h3>{animal.name}</h3>
        <p>Species: {animal.species}</p>
        <p>Feeding Cost: ${animal.cost}</p>
      </article>
    </>
  )
}

export default Individual