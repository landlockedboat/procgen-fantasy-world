using System;
using System.Collections.Generic;

[Serializable]
public class Settlement
{
    public Settlement(int population, SettlementType type)
    {
        name = PlaceNameGenerationController.GetRandomPlaceName();
        this.population = population;
        this.type = type;
        businessList = BusinessListGeneratorController.GetNumberOfBusinessFromSettlementPopulation(this.population);
    }

    public string name;
    public SettlementType type;
    public int population;
    public List<Business> businessList;
}