import './Individual.css'

function Individual({animal}) {

  return (
    <>
      <article className='animalCard'>
        <img src={animal.image} alt={`${animal.name} the ${animal.species}`} />
        <h3>{animal.name}</h3>
        <h4>{animal.species}, Weight: {animal.weight}kg</h4>
        <p>{animal.diet}</p>
        <p>Feeding Cost: ${animal.cost}</p>
      </article>
    </>
  )
}

export default Individual