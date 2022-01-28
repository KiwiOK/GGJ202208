using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float limite = 3.42f;
    //private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       // anim = GetComponent<Animator>();
    }

    //Se mueve en el eje z
    // Update is called once per frame
    //TODO: definir altura del salto
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && gameObject.transform.position.z != limite)
        {
            move("left");
        }
        else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && gameObject.transform.position.z != -limite)
        {
            move("right");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
    }
    void move(string movement)
    {
        if (movement == "left")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + limite);
        }
        else if(movement == "right")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z- limite);
        }
    }
    void jump()
    {
        
    }

}
