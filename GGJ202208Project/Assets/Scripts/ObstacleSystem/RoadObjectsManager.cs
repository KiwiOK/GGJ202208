using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObjectsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _spawners;
    [SerializeField]
    private float _minTimeSpawn;
    [SerializeField]
    private float _maxTimeSpawn;

    private float _timerBetweenSpawns;
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
        int randomSpawner = Random.Range(0, 3);
        print("random Spawner: " + randomSpawner);
        GameObject SpawnerSelected = _spawners[randomSpawner];

        int randomGoodOrBad = Random.Range(0, 8);

        if (randomGoodOrBad == 1 && SpawnerSelected.GetComponent<SpawnerRoadObject>())
        {
            print("SpawnGOOD: " + randomGoodOrBad);
            _spawners[randomSpawner].GetComponent<SpawnerRoadObject>().SpawnGoodObject();
        }
        else
        {
            print("SpawnBAD: " + randomGoodOrBad);
            _spawners[randomSpawner].GetComponent<SpawnerRoadObject>().SpawnBadObject();
        }
        _timeSpawn = Random.Range(_minTimeSpawn, _maxTimeSpawn);
        _timerBetweenSpawns = 0;

        print("_timeSpawn: " + _timeSpawn);
    }
}