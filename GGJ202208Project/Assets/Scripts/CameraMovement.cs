using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private Vector3 topVector = new Vector3(0, 1, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, transform.position.z);
            if(transform.position.y<0)
                transform.LookAt(target.transform, Vector3.down);
            else
                transform.LookAt(target.transform, Vector3.up);
        }
    }
}
