import './Animal.css'

function Animal({animal}) {

  return (
    <>
      <article className='animalCard' alt={`${animal.name} the ${animal.species}`}>
        <img src={animal.image} alt={`${animal.name} the ${animal.species}`} />
        <h3>{animal.name}</h3>
        <h4>{animal.species}, Weight: {animal.weight}kg</h4>
        <p>{animal.diet}</p>
        <p>Feeding Cost: ${animal.cost}</p>
      </article>
    </>
  )
}

export default Animal