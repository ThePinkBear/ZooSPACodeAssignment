public class AnimalHandler : IAnimalHandler
{
    private List<Animal> _animals;
    private Dictionary<string, SpeciesDietInformation> _speciesInformation;
    private List<Price> _prices;

    public AnimalHandler(IFileReader reader)
    {
        _animals = reader.ReadAnimals();
        _speciesInformation = reader.ReadSpeciesInformation().ToDictionary(si => si.Species);
        _prices = reader.ReadPrices();
    }
    public List<AnimalDTO> GetAnimalDataTransferObjects()
    {
        return _animals.Where(animal => _speciesInformation.ContainsKey(animal.Species)).Select(animal => new AnimalDTO
        {
            Id = Guid.NewGuid(),
            Species = animal.Species,
            Name = animal.Name,
            Diet = _speciesInformation[animal.Species].DietType,
            Weight = animal.Weight,
            Cost = Math.Round(_speciesInformation[animal.Species].CalculateIndividualCost(_prices, animal), 2),
            Image = animal.Image
        }).ToList();
    }

    public double CalculateTotalCost()
    {
        return Math.Round(_animals.Where(animal => _speciesInformation.ContainsKey(animal.Species))
            .Sum(animal => _speciesInformation[animal.Species].CalculateIndividualCost(_prices, animal)), 2);
    }

    public double CalculateMeatCost()
    {
        return Math.Round(SortByDiet("meat").Sum(animal => CalculateDietCost(animal, _speciesInformation[animal.Species].MeatPercentage)), 2);
    }

    public double CalculateFruitCost()
    {
        return Math.Round(SortByDiet("fruit").Sum(animal => CalculateDietCost(animal, _speciesInformation[animal.Species].FruitPercentage)), 2);
    }

    private double CalculateDietCost(Animal animal, int dietPercentage)
    {
        return _speciesInformation[animal.Species].CalculateIndividualCost(_prices, animal) * (dietPercentage / 100.0);
    }

    private List<Animal> SortByDiet(string diet)
    {
        return _animals.Where(animal => _speciesInformation.ContainsKey(animal.Species) && (_speciesInformation[animal.Species].Diet == diet || _speciesInformation[animal.Species].Diet == "both")).ToList();
    }
}
