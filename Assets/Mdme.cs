using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Mdme : MonoBehaviour
{
    [SerializeField] private int seed = 420;

    [SerializeField]
    // Current day Spain
    private float realmSurfaceAreaInSquareMiles = 200000;

    // XIV Century France = 100 people/sq.mile
    // XIV Century Germany = 90 people/sq.mile
    // XIV Century Italy = 90 people/sq.mile
    // XIV Century British Isles = 40 people/sq.mile
    // XIV Century Spain = 30 people/sq.mile
    [Range(30, 120)] [SerializeField] private float realmPopulationDensityInPeoplePerSquareMile = 60;

    private int _totalRealmPopulation;

    private int _populationOfLargestCityInRealm;
    private int _populationOfSecondLargestCityInRealm;

    private List<int> _otherCitiesPopulation = new List<int>();

    private int _numberOfTowns;

    private int _numberOfCastles;

    private float _settledLandInSquareMiles;

    // Start is called before the first frame update
    private void Start()
    {
        Random.InitState(seed);

        _totalRealmPopulation =
            Mathf.FloorToInt(realmSurfaceAreaInSquareMiles * realmPopulationDensityInPeoplePerSquareMile);

        _settledLandInSquareMiles = _totalRealmPopulation / 180.0f;

        _numberOfCastles = Mathf.FloorToInt(_totalRealmPopulation / (50.0f * 1000.0f));

        _populationOfLargestCityInRealm =
            Mathf.FloorToInt(Mathf.Sqrt(_totalRealmPopulation) * (2 * DiceRoller.RollDice(4) + 10));

        // 20% to 80% of populationOfLargestCityInKingdom
        _populationOfSecondLargestCityInRealm =
            Mathf.FloorToInt(2 * DiceRoller.RollDice(4) * 10 / 100.0f * _populationOfLargestCityInRealm);

        var prevCityPopulation = _populationOfSecondLargestCityInRealm;
        var nextCityPopulation = prevCityPopulation - Mathf.FloorToInt(2 * DiceRoller.RollDice(4) * 5 / 100.0f * prevCityPopulation);
        while (nextCityPopulation >= 8000)
        {
            _otherCitiesPopulation.Add(nextCityPopulation);
            prevCityPopulation = nextCityPopulation;
            // 10% to 40% smaller
            nextCityPopulation = prevCityPopulation -
                                 Mathf.FloorToInt(2 * DiceRoller.RollDice(4) * 5 / 100.0f * prevCityPopulation);
        }

        _numberOfTowns = _otherCitiesPopulation.Count * 2 * DiceRoller.RollDice(8);

        var finalMessage = $"Realm surface: {realmSurfaceAreaInSquareMiles} sq.miles {Environment.NewLine}" +
                           $"Settled land: {_settledLandInSquareMiles} sq.miles ({_settledLandInSquareMiles / realmSurfaceAreaInSquareMiles * 100.0f}% of total realm land) {Environment.NewLine}" +
                           $"Realm population density: {realmPopulationDensityInPeoplePerSquareMile} people / sq.mile {Environment.NewLine}" +
                           $"Total realm population: {_totalRealmPopulation} people {Environment.NewLine}" +
                           $"Number of cities : {_otherCitiesPopulation.Count + 2} cities {Environment.NewLine}" +
                           $"Number of towns : {_numberOfTowns} towns {Environment.NewLine}" +
                           $"Number of castles : {_numberOfCastles} castles {Environment.NewLine}" +
                           $"City populations: {Environment.NewLine}" + 
                           $"  City 1 : {_populationOfLargestCityInRealm} people {Environment.NewLine}" +
                           $"  City 2 : {_populationOfSecondLargestCityInRealm} people {Environment.NewLine}";
        
        for (var i = 0; i < _otherCitiesPopulation.Count; i++)
        {
            finalMessage += $"  City {i + 3} : {_otherCitiesPopulation[i]} people {Environment.NewLine}";
        }
        
        Debug.Log(finalMessage);
    }
}

public static class DiceRoller
{
    public static int RollDice(int diceSides)
    {
        return Random.Range(0, diceSides) + 1;
    }
}