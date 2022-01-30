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

    private bool _isPlatformFlipped;

    private float _globalTimer;
    private bool _isDejavu = false;
    private bool _isCodigoLimpio = false;

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
        _globalTimer += Time.deltaTime;

        if (_timerBetweenSpawns > _timeSpawn)
        {
            SpawnNewRoadObject();
        }
    }

    void SpawnNewRoadObject()
    {
        int randomSpawner = Random.Range(0, 3);
        if (IsPlatformFlipped)
        {
            randomSpawner = Random.Range(3, 6);
        }

        GameObject SpawnerSelected = _spawners[randomSpawner];


        int randomGoodOrBad = Random.Range(0, 8);

        //Spawn Power Up
        if (randomGoodOrBad == 1 && SpawnerSelected.GetComponent<SpawnerRoadObject>())
        {
            _spawners[randomSpawner].GetComponent<SpawnerRoadObject>().SpawnGoodObject();
        }
        else
        {
            //Spawn obstacle
            _spawners[randomSpawner].GetComponent<SpawnerRoadObject>().SpawnBadObject();
        }
        _timeSpawn = Random.Range(_minTimeSpawn, _maxTimeSpawn);
        _timerBetweenSpawns = 0;

        if (!_isDejavu)
        {
            ChangeRangeValues();
        }

        //print("_timeSpawn: " + _timeSpawn);
    }


    private void ChangeRangeValues()
    {
        //Debug.Log(_globalTimer);

        if (_globalTimer > 60)
        {
            //HOLY GUACAMOLY

            _isDejavu = true;
            _minTimeSpawn = 1;
            _maxTimeSpawn = 2;
           //gameObject.SendMessage("IncreaseSpeed", 10);

        }
        else if (!_isCodigoLimpio && (_globalTimer > 30 && _globalTimer < 60))
        {
            _isCodigoLimpio = true;
            _minTimeSpawn = 2;
            _maxTimeSpawn = 4;
            //gameObject.SendMessage("IncreaseSpeed", 10);
        }
    }
}