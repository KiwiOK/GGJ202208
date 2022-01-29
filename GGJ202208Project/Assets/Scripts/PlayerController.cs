using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float limite = 2f;
    bool isGrounded, up = false;
    [SerializeField]
    private bool bad = false;
    [SerializeField]
    private int jumpHeight = 3;
    [SerializeField]
    private float velUp = 3, velDownDiff = 0.2f;
    private float vel, jumpPos, posIni, posUp, velDown;
    private int aux = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (bad)
            aux = -1;
        jumpPos = transform.position.y;
        posIni = transform.position.y;
        posUp = (transform.position.y + (aux * jumpHeight));
        isGrounded = true;
        velDown = velUp + velDownDiff;
        vel = velUp;
    }
    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    //Se mueve en el eje z
    // Update is called once per frame
    //TODO: definir altura del salto
    //TODO: *-1 cuando pasen un bool
    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                if (!bad)
                    moveLeft();
                else
                    moveRight();
            }

            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                if (bad)
                    moveLeft();
                else
                    moveRight();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpPos = posUp;
                isGrounded = false;
                up = true;
            }
        }

        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
                                                   new Vector3(gameObject.transform.position.x, jumpPos, gameObject.transform.position.z),
                                                   Time.deltaTime * vel);

        if (isGrounded == false)
        {
            if (up && Mathf.Abs(gameObject.transform.position.y) >= (Mathf.Abs(posUp) - 0.15))
            {
                //gameObject.transform.position = new Vector3(gameObject.transform.position.x, posUp, gameObject.transform.position.z);
                jumpPos = posIni;
                vel = velDown;
                up = false;
            }
            else if (!up && Mathf.Abs(gameObject.transform.position.y) <= (Mathf.Abs(posIni) + 0.15))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, posIni, gameObject.transform.position.z);
                isGrounded = true;
                vel = velUp;
            }
        }
    }

    void moveLeft()
    {
        if (gameObject.transform.position.z > -limite)
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - limite);
    }
    void moveRight()
    {
        if (gameObject.transform.position.z < limite)
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + limite);
    }
}
