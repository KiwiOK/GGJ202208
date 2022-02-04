using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScroll : MonoBehaviour
{
    // Start is called before the first frame update
    public float ScrollX = 0.5f;
    public float ScrollY = 0.5f;
    public bool start;
    void Start()
    {
        start = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            float OffSetX = Time.time * ScrollX;
            float offSetY = Time.time * ScrollY;
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffSetX, offSetY);
        }
        else { Invoke("pasotiempo", 2); }

    }
    void pasotiempo()
    {
        start = !start;
    }

}
