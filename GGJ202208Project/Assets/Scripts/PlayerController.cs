using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float limite = 2f;
    private Rigidbody rb;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        isGrounded = true;
    }

    //Se mueve en el eje z
    // Update is called once per frame
    //TODO: definir altura del salto
    //TODO: *-1 cuando pasen un bool
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && gameObject.transform.position.z > -limite)
        {
            move("left");
        }
        else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && gameObject.transform.position.z < limite)
        {
            print(gameObject.transform.position.z);
            move("right");
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump();
        }
    }
    void move(string movement)
    {
        if (movement == "left")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - limite);
        }
        else if(movement == "right")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + limite);
        }
    }
    void jump()
    {
        isGrounded = false;
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(gameObject.transform.position.x, 50, gameObject.transform.position.z), Time.deltaTime * 10);
        //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(gameObject.transform.position.x, -50, gameObject.transform.position.z), Time.deltaTime * 10);
        //isGrounded = true;
    }
}
