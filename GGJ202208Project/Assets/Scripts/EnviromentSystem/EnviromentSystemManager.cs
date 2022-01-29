using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentSystemManager : MonoBehaviour 
{
    [SerializeField]
    private GameObject[] _spawners;
    [SerializeField]
    private float _minTimeSpawn;
    [SerializeField]
    private float _maxTimeSpawn;

    private float _timerBetweenSpawns;
    private float _timeSpawn;

    private bool _isPlatformFlipped;

    public bool IsPlatformFlipped { get => _isPlatformFlipped; set => _isPlatformFlipped = value; }

    // Start is called before the first frame update
    void Start()
    {
        _isPlatformFlipped = false;
    }

// Update is called once per frame
    void Update()
    {
        _timerBetweenSpawns += Time.deltaTime;
        if (_timerBetweenSpawns > _timeSpawn)
        {
            SpawnNewEnviromentObject();
        }
    }

    void SpawnNewEnviromentObject()
    {
        int randomSpawner = 0;
        if (IsPlatformFlipped)
        {
            randomSpawner = 1;
        }
        GameObject SpawnerSelected = _spawners[randomSpawner];

        if (SpawnerSelected.GetComponent<SpawnerEnviromentObject>())
        {
            _spawners[randomSpawner].GetComponent<SpawnerEnviromentObject>().SpawnEnviromentObject();
        }
        _timeSpawn = Random.Range(_minTimeSpawn, _maxTimeSpawn);
        _timerBetweenSpawns = 0;

        //print("_timeSpawn: " + _timeSpawn);
    }
}
