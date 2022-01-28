using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerDeslizar : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
    }
    //EL ancho son 3 posiciones
    //Se mueve en el eje z
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            move("left");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            move("right");
        }
    }
    void move(string movement)
    {
        if (movement == "left")
        {
            for (int i = 0; i < 3; ++i) {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + i);
                print(gameObject.transform.position);
            }
        }
        else if (movement == "right")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 3.42f);
            print(gameObject.transform.position);
        }

    }
}
