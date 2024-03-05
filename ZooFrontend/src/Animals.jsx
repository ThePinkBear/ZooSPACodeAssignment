import Animal from "./Animal"

function Animals({animals}) {

  return (
    <>
      <section>
        {animals.map(animal => (
          <Animal key={animal.id} animal={animal}/>
        ))}
      </section>
    </>
  )
}

export default Animals