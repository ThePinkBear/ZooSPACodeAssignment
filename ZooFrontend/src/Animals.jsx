import Individual from './Individual'


function Animals({animals}) {

  return (
    <>
      <section>
        {animals.map(animal => (
          <Individual key={animal.id} animal={animal}/>
        ))}
      </section>
    </>
  )
}

export default Animals