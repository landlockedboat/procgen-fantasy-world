using System;
using System.IO;
using System.Net.Http.Headers;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class RealmGenerationController : MonoBehaviour
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
    
    private void Start()
    {
        Random.InitState(seed);
        var realmToGenerate = new Realm(realmSurfaceAreaInSquareMiles, realmPopulationDensityInPeoplePerSquareMile);
        var path = Application.persistentDataPath + Path.PathSeparator + DateTime.Now.Ticks + "-realm.json";

        //Write some text to the test.txt file
        var writer = new StreamWriter(path, true);
        writer.WriteLine(JsonUtility.ToJson(realmToGenerate, true));
        writer.Close();
        EditorUtility.RevealInFinder(Application.persistentDataPath);
    }
}