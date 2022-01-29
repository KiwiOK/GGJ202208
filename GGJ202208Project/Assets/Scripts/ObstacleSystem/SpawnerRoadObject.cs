using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRoadObject : MonoBehaviour
{
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

    public void SpawnGoodObject()
    {
        GameObject objectToSpawn = FirstObjectReady(_poolGoodObjects);
        if (objectToSpawn == null)
        {
            print("NO QUEDAN COSAS BUENAS QUE SPAWNEAR");
        }
        else
        {
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = this.transform.position;
        }

    }
    public void SpawnBadObject()
    {
        GameObject objectToSpawn = FirstObjectReady(_poolBadObjects);
        if (objectToSpawn == null)
        {
            print("NO QUEDAN COSAS MALAS QUE SPAWNEAR");
        }
        else
        {
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = this.transform.position;
        }
    }
}
