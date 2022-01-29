using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float limite = 2f;
    private Rigidbody rb;
    bool isGrounded;
    private int jumpHeight = 3;
    private float jumpPos = 0.5f, vel = 2, velUp = 2, velDown=2.3f;
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
        else if (movement == "right")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + limite);
        }
    }
    void jump()
    {
        jumpPos = gameObject.transform.position.y + jumpHeight;
        isGrounded = false;
        print(gameObject.transform.position);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, 
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+30, 
            gameObject.transform.position.z), Time.deltaTime * 10);
        print(gameObject.transform.position);
        /*int i = 0;
        while( i < 1000000000000000000) { ++i; }
        
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 30, gameObject.transform.position.z), Time.deltaTime * 10);
        */
        
        //isGrounded = true;
    }
    private void LateUpdate()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
                                                    new Vector3(gameObject.transform.position.x, jumpPos, gameObject.transform.position.z),
                                                    Time.deltaTime * vel);
        if (!isGrounded)
        {
            if (Mathf.Abs(gameObject.transform.position.y) >= (Mathf.Abs(jumpPos)-0.2))
            {
                jumpPos = 0.5f;
                vel = velDown;
            }
            if (Mathf.Abs(gameObject.transform.position.y) <= 0.5)
            {
                isGrounded = true;
                vel = velUp;
            }
        }


    }
}
