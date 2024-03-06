import { useState, useEffect } from 'react';
import { Chart } from 'react-google-charts';
import './Metrics.css';


function Metrics ({ animals, meatCost, fruitCost }) {
  const [animalData, setAnimalData] = useState([["Name", "Weight"]]);
  const [dietData, setDietData] = useState([["Diet", "Count"]]);
  const [costData, setCostData] = useState([["Item", "Cost"], ["Meat", 0], ["Fruit", 0]]);

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
    setCostData([["Item", "Cost"], ["Meat", meatCost], ["Fruit", fruitCost]]);
  }, [animals]);

  return (
    <>
    <section className="metrics">
      <article className='chartArticle'>
        <h4>Animal Weights:</h4>
        <Chart
          chartType="ScatterChart"
          data={animalData}
          width= "100%"
          height="100%"
          options={{
            legend: 'none',
            backgroundColor: 'transparent',
            colors: ['#32692f'],
            fontSize: 18,
            textStyle: {
              color: '#FFF'
            },
            hAxis: {
              textStyle: {
                color: '#FFF',
              },
              color: '#FFF',
              title: 'Animals'
            },
            vAxis: {
              title: 'Weight (Kg)'
            }
          }}
        />
        </article>
        <article className='chartArticle'>
          <h4>Animal Diet Ratio:</h4>
          <Chart
          chartType="PieChart"
          data={dietData}
          width="100%"
          height="100%"
          options={{
            backgroundColor: 'transparent',
            colors: ['#e0440e', '#32692f', '#2d3866'],
            is3D: true
          }}
          />
        </article>
        <article className='chartArticle'>
          <h4>Cost of Meat vs Fruit:</h4>
          <Chart
            chartType="ColumnChart"
            data={costData}
            width="100%"
            height="100%"
            options={{
              legend: 'none',
              backgroundColor: 'transparent',
              colors: ['#32692f'],
              chartArea: { width: '60%' },
              fontSize: 18,
              textStyle: {
                color: '#FFF'
              },
              hAxis: {
                textStyle:{
                  color: '#FFF',
                  fontSize: 16
                }
              },
              vAxis: {
                textStyle:{
                  color: '#FFF',
                  fontSize: 16
                }
              },
            }}
          />
        </article>
      </section>
    </>
  );
}

export default Metrics;