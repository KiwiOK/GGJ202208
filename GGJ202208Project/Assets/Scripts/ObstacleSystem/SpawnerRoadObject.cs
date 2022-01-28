using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRoadObject : MonoBehaviour
{
    [SerializeField]
    private int time;
    [SerializeField]
    private GameObject[] _poolGoodObjects;
    //[SerializeField]
    private GameObject[] _poolBadObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject FirstObjectReady(GameObject[] objectList) {
        GameObject result;
        for (int i = 0; i < objectList.Length; i++)
		{
            if (!objectList[i].activeSelf)
            {
                result = objectList[i];
                return result;
            }
		}
        return null;
    }

    void SpawnGoodObject()
    {
        GameObject objectToSpawn = FirstObjectReady(_poolGoodObjects);
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = this.transform.position;
    }
    void SpawnBadObject()
    {
        GameObject objectToSpawn = FirstObjectReady(_poolBadObjects);
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = this.transform.position;
    }
}
