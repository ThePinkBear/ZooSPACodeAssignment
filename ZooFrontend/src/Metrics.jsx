import { useState, useEffect } from 'react';
import { Chart } from 'react-google-charts';
import './Metrics.css';


function Metrics ({ animals }) {
  const [animalData, setAnimalData] = useState([["Name", "Weight"]]);

  const populateAnimalsByWeight = () => {
    const header = [["Name", "Kilos"]];
    const mappedAnimals = animals.map(animal => [animal.name, animal.weight]);
    setAnimalData(header.concat(mappedAnimals));
  }

  useEffect(() => {
    populateAnimalsByWeight();
  }, [animals]);

  return (
    <>
    <section className="metrics">
      <article className='chartArticle'>
        <h4>Animal Weights:</h4>
        <Chart
          chartType="ScatterChart"
          data={animalData}
          width= "90%"
          height="50%"
        />
      </article>
    </section>
    </>
  );
}

export default Metrics;