using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObject : MonoBehaviour
{
    [SerializeField]
    private int _effectQuantity;
    [SerializeField]
    private int _objectVelocityIncrement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1.0f, 0f, 0f) * Time.deltaTime * _objectVelocityIncrement, Space.World);
    }
}
