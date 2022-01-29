using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float limite = 2f;
    bool isGrounded, up=false;
    [SerializeField]
    private int jumpHeight = 3;
    [SerializeField]
    private float velUp = 3, velDownDiff = 0.2f;
    private float vel, jumpPos, posIni, posUp, velDown;
    private int live;
    // Start is called before the first frame update
    void Start()
    {
        jumpPos = transform.position.y;
        posIni = transform.position.y;
        posUp = transform.position.y + jumpHeight;
        isGrounded = true;
        velDown = velUp + velDownDiff;
        vel = velUp;
        live = 3;
    }

    //Se mueve en el eje z
    // Update is called once per frame
    //TODO: definir altura del salto
    //TODO: *-1 cuando pasen un bool
    void Update()
    {
        if (isGrounded)
        {
            if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && gameObject.transform.position.z > -limite)
            {
                move("left");
            }
            else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && gameObject.transform.position.z < limite)
            {
                move("right");
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
            if (up && gameObject.transform.position.y >= (Mathf.Abs(posUp) - 0.15))
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

    }
    public void subLive(int quantity)
    {
        if (live > 0 && live < 3)
        {
            live += quantity;
            return;
        }
        //Llamar a muerte
    }
    public int LiveGetter() { return live; }
    public void LiveSetter(int _live) { live = live;}
}
