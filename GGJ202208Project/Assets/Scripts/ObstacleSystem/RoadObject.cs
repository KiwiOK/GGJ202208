using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObject : MonoBehaviour
{
    [SerializeField]
    private int _effectQuantity;
    [SerializeField]
    private int _objectVelocityIncrement;
    [SerializeField]
    private AudioSource _collisionSoundSrc;


    // Start is called before the first frame update
    void Start()
    {
        _collisionSoundSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1.0f, 0f, 0f) * Time.deltaTime * _objectVelocityIncrement, Space.World);
    }


    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                //ToDo Restar/Sumar salud mental al player
                //Llamar a la funcion del player con cantidad negativa/Positiva de _effectQuantity según el objeto que sea

                //collision.gameObject.GetComponent()
                //Sonido al colisionar con el objeto??
                // _collisionSoundSrc.Play();
                collision.gameObject.GetComponent<PlayerController>().subLive(_effectQuantity);
                
                // Desactivamos el GO
                this.gameObject.SetActive(false);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EndWall")
            // Desactivamos el GO
            this.gameObject.SetActive(false);

    }
}

