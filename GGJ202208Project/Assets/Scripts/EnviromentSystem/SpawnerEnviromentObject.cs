using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnviromentObject : MonoBehaviour
{

    [SerializeField]
    private GameObject[] _poolEnviromentObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject FirstObjectReady(GameObject[] objectList)
    {
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

    public void SpawnEnviromentObject()
    {
        GameObject objectToSpawn = FirstObjectReady(_poolEnviromentObjects);
        if (objectToSpawn == null)
        {
            print("NO QUEDA ENVIROMENT PARA SPAWNEAR");
        }
        else
        {
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = this.transform.position;
        }

    }
}
