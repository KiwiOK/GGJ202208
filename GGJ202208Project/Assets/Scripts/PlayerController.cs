using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float limite = 2f;
    bool isGrounded;
    [SerializeField]
    private int jumpHeight = 3;
    [SerializeField]
    private float velUp = 3, velDownDiff = 0.2f;
    private float vel, jumpPos, posIni, posUp, velDown;
    // Start is called before the first frame update
    void Start()
    {
        jumpPos = transform.position.y;
        posIni = transform.position.y;
        posUp = transform.position.y + jumpHeight;
        isGrounded = true;
        velDown = velUp + velDownDiff;
        vel = velUp;
    }

    //Se mueve en el eje z
    // Update is called once per frame
    //TODO: definir altura del salto
    //TODO: *-1 cuando pasen un bool
    void Update()
    {
        if (isGrounded && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && gameObject.transform.position.z > -limite)
        {
            move("left");
        }
        else if (isGrounded && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && gameObject.transform.position.z < limite)
        {
            //print(gameObject.transform.position.z);
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
        jumpPos = posUp;
        isGrounded = false;
    }
    private void LateUpdate()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
                                                    new Vector3(gameObject.transform.position.x, jumpPos, gameObject.transform.position.z),
                                                    Time.deltaTime * vel);
        if (!isGrounded)
        {
            if (Mathf.Abs(gameObject.transform.position.y) >= (Mathf.Abs(posUp) - 0.1))
            {
                jumpPos = posIni;
                vel = velDown;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, posUp, gameObject.transform.position.z);
            }
            if (Mathf.Abs(gameObject.transform.position.y) <= (Mathf.Abs(posIni) + 0.1))
            {
                isGrounded = true;
                vel = velUp;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, posIni, gameObject.transform.position.z);
                Debug.Log(gameObject.transform.position.y);
            }
        }


    }
}
