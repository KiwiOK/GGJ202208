using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentObject : MonoBehaviour
{
    [SerializeField]
    private int _objectVelocityIncrement;
    [SerializeField]
    private AudioSource _collisionSoundSrc;

    void Start()
    {
        _collisionSoundSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1.0f, 0f, 0f) * Time.deltaTime * _objectVelocityIncrement, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EndWall")
            // Desactivamos el GO
            this.gameObject.SetActive(false);

    }
}