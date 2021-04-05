using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class Realm
{
    private const float PeopleSupportedPerSquareOfArableLand = 180;
    private const float PopulationPerCastle = 50_000;
    private const int MinPopulationToBeConsideredACity = 8_000;

    public string name;

    public float surfaceArea;
    public float populationDensity;
    public int population;

    public float settledLandInSquareMiles;
    public int numberOfCastles;

    public List<Settlement> GetCities()
    {
        return settlements.Where(settlement =>
            settlement.type == SettlementType.City || settlement.type == SettlementType.BigCity).ToList();
    }

    public List<Settlement> settlements = new List<Settlement>();

    public Realm(float surfaceArea, float populationDensity)
    {
        name = CountryNameGenerationController.GetRandomCountryName();
        this.surfaceArea = surfaceArea;
        this.populationDensity = populationDensity;
        population = Mathf.FloorToInt(this.surfaceArea * this.populationDensity);
        settledLandInSquareMiles = population / PeopleSupportedPerSquareOfArableLand;
        numberOfCastles = Mathf.FloorToInt(population / PopulationPerCastle);
        GenerateSettlements();
    }

    private void GenerateSettlements()
    {
        GenerateCities();
        GenerateTowns();
        GenerateVillages();
    }

    private void GenerateCities()
    {
        var initialCityPopulation = Mathf.FloorToInt(GetPopulationOfFirstCity(population));
        var nextCityPopulation = initialCityPopulation;

        while (nextCityPopulation >= MinPopulationToBeConsideredACity)
        {
            settlements.Add(new Settlement
            (
                nextCityPopulation,
                nextCityPopulation > 12_000 ? SettlementType.BigCity : SettlementType.City
            ));
            nextCityPopulation -= Mathf.FloorToInt(nextCityPopulation * Random.Range(.1f, .4f));
        }
    }

    private void GenerateTowns()
    {
        var numberOfTowns = GetCities().Count * Random.Range(2, 16);

        for (var i = 0; i < numberOfTowns; i++)
        {
            settlements.Add(new Settlement
            (
                Random.Range(1_000, 8_000),
                SettlementType.Town
            ));
        }
    }

    private void GenerateVillages()
    {
        var settledPopulationSoFar = settlements.Sum(settlement => settlement.population);
        var populationThatNeedsToBeSettled = population - settledPopulationSoFar;

        while (populationThatNeedsToBeSettled > 0)
        {
            var nextVillagePopulation = Random.Range(20, 1_000);
            settlements.Add(new Settlement
            (
                nextVillagePopulation,
                SettlementType.Village
            ));

            populationThatNeedsToBeSettled -= nextVillagePopulation;
            if (populationThatNeedsToBeSettled < 0)
            {
                settlements.Last().population += populationThatNeedsToBeSettled;
                populationThatNeedsToBeSettled = 0;
            }
        }
    }

    private static float GetPopulationOfFirstCity(float realmPopulation)
    {
        return Mathf.Sqrt(realmPopulation) * Random.Range(12, 18);
    }
}