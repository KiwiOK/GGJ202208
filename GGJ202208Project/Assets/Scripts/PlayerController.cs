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
    private int lifesLimit, maxLifes, currentLifes, minLifes;
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (bad)
            aux = -1;
        jumpPos = transform.position.y;
        posIni = transform.position.y;
        posUp = (transform.position.y + (aux * jumpHeight));
        isGrounded = true;
        velDown = velUp + velDownDiff;
        vel = velUp;
        //live = 3;
    }

    public void SetLifesLimit(int max)
    {
        maxLifes = max;
        currentLifes = max;

    }

    public void SetLifesLimit(int max, int min)
    {        
        maxLifes = max;
        minLifes = min;
        currentLifes = 0;
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
        //if (Input.GetKeyDown(KeyCode.B))
        //    subLive(-1);
        //if (Input.GetKeyDown(KeyCode.S))
        //    subLive(1);
        if (isGrounded)
        {
            if (currentLifes == 0)
                gameObject.GetComponent<Animator>().Play("Walking_3-3");
            else if (currentLifes % 3 == 0)
                gameObject.GetComponent<Animator>().Play("Walking_Color");
            else if (currentLifes % 3 == 1)
                gameObject.GetComponent<Animator>().Play("Walking_1-3");
            else if (currentLifes % 3 == 2)
                gameObject.GetComponent<Animator>().Play("Walking_2-3");
            

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
                if(currentLifes%3 == 0)
                    gameObject.GetComponent<Animator>().Play("Jump_Color");
                else if (currentLifes % 3 == 1)
                    gameObject.GetComponent<Animator>().Play("Jump_1-3");
                else if (currentLifes % 3 == 2)
                    gameObject.GetComponent<Animator>().Play("Jump_2-3");
                else if (currentLifes % 3 == 3)
                    gameObject.GetComponent<Animator>().Play("Jump_3-3");
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
                if (currentLifes == 0)
                    gameObject.GetComponent<Animator>().Play("Walking_3-3");
                else if (currentLifes % 3 == 0)
                    gameObject.GetComponent<Animator>().Play("Walking_Color");
                else if (currentLifes % 3 == 1)
                    gameObject.GetComponent<Animator>().Play("Walking_1-3");
                else if (currentLifes % 3 == 2)
                    gameObject.GetComponent<Animator>().Play("Walking_2-3");
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

    public void subLive(int quantity)
    {
        currentLifes += quantity;
        Debug.Log("Current " + currentLifes);
        if (!bad)
        {
            if (currentLifes <= 0)
            {
                currentLifes = 0;
                gameManager.HandleLifes(true, currentLifes);
            }
            else if (currentLifes >= maxLifes)
                currentLifes = maxLifes;
        }
        else
        {
            if (currentLifes <= -minLifes)
            {
                currentLifes = minLifes;
                Debug.Log("Dah");
                gameManager.HandleLifes(false, -currentLifes);
            }
            else if (currentLifes >= maxLifes)
            {
                currentLifes = maxLifes;
                gameManager.HandleLifes(false, currentLifes);
            }
        }
    }

    public void Fall()
    {
        print("AAAAAAAAAA");
        gameObject.GetComponent<Animator>().Play("Fall_3-3");
    }

    public int LiveGetter() { return currentLifes; }
    public void LiveSetter(int _live) { currentLifes = _live; }
}
