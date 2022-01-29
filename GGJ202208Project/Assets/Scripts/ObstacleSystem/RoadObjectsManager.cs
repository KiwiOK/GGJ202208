using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _spawnerRoadObjects;

    [SerializeField]
    private float _timerBetweenSpawns;
    [SerializeField]
    private float _minTimeSpawn;
    [SerializeField]
    private float _maxTimeSpawn;

    private float _timeSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timerBetweenSpawns += Time.deltaTime;
        if (_timerBetweenSpawns > _timeSpawn)
		{
            SpawnNewRoadObject();
		}  
    }

    void SpawnNewRoadObject() 
    {
        int randomSpawner = Random.Range(0, 2);
        print("random Spawner: "+ randomSpawner);
        GameObject SpawnerSelected = _spawnerRoadObjects[randomSpawner];

        int randomGoodOrBad = Random.Range(0, 8);

		if (randomGoodOrBad == 1 && SpawnerSelected.GetComponent<SpawnerRoadObject>())
		{
            print("SpawnGOOD: " + randomGoodOrBad);
            _spawnerRoadObjects[randomSpawner].GetComponent<SpawnerRoadObject>().SpawnGoodObject();
        }
		else
		{
            print("SpawnBAD: " + randomGoodOrBad);
            _spawnerRoadObjects[randomSpawner].GetComponent<SpawnerRoadObject>().SpawnBadObject();
        }
        _timeSpawn = Random.Range(_minTimeSpawn, _maxTimeSpawn);
        print("_timeSpawn: " + _timeSpawn);
    }
}
