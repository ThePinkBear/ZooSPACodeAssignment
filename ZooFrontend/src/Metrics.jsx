import { useState, useEffect } from 'react';
import { Chart } from 'react-google-charts';
import './Metrics.css';


function Metrics ({ animals }) {
  const [animalData, setAnimalData] = useState([["Name", "Weight"]]);
  const [dietData, setDietData] = useState([["Diet", "Count"]]);

  const populateAnimalsByWeight = () => {
    const header = [["Name", "Kilos"]];
    const mappedAnimals = animals.map(animal => [animal.name, animal.weight]);
    setAnimalData(header.concat(mappedAnimals));
  }
  const populateDietData = () => {
    const dietCounts = animals.reduce((acc, animal) => {
      acc[animal.diet] = (acc[animal.diet] || 0) + 1;
      return acc;
    }, {});

    const mappedDietData = Object.entries(dietCounts).map(([diet, count]) => [diet, count]);
    setDietData([["Diet", "Count"]].concat(mappedDietData));
  }

  useEffect(() => {
    populateAnimalsByWeight();
    populateDietData();
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
        <article className='chartArticle'>
        <h4>Animal Diet Ratio:</h4>
        <Chart
        chartType="PieChart"
        data={dietData}
        width="90%"
        height="50%"
        options={{
          is3D: true,
        }}
      />
      </article>
    </section>
    </>
  );
}

export default Metrics;