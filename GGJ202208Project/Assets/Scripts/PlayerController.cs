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
    private int maxLifes, currentLifes, minLifes, animCont;
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
        //animCont = 3;
        //live = 3;
    }
    private void OnEnable()
    {if (bad) animCont = 0;
        else animCont = 3;
    }

    public void SetLifesLimit(int max)
    {
        maxLifes = max;
        currentLifes = max;
        UpdateAnim();

    }

    public void SetLifesLimit(int max, int min)
    {
        maxLifes = max;
        minLifes = min;
        currentLifes = 0;
        UpdateAnim();
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
            switch (animCont)
            {
                case 0:
                    gameObject.GetComponent<Animator>().Play("Walking_3-3");
                    break;
                case 1:
                    gameObject.GetComponent<Animator>().Play("Walking_2-3");
                    break;
                case 2:
                    gameObject.GetComponent<Animator>().Play("Walking_1-3");
                    break;
                case 3:
                    gameObject.GetComponent<Animator>().Play("Walking_Color");
                    break;
                default:
                    break;
            }

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

                switch (animCont)
                {
                    case 0:
                        gameObject.GetComponent<Animator>().Play("Jump_3-3");
                        break;
                    case 1:
                        gameObject.GetComponent<Animator>().Play("Jump_2-3");
                        break;
                    case 2:
                        gameObject.GetComponent<Animator>().Play("Jump_1-3");
                        break;
                    case 3:
                        gameObject.GetComponent<Animator>().Play("Jump_Color");
                        break;
                    default:
                        break;
                }
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
                switch (animCont)
                {
                    case 0:
                        gameObject.GetComponent<Animator>().Play("Walking_3-3");
                        break;
                    case 1:
                        gameObject.GetComponent<Animator>().Play("Walking_2-3");
                        break;
                    case 2:
                        gameObject.GetComponent<Animator>().Play("Walking_1-3");
                        break;
                    case 3:
                        gameObject.GetComponent<Animator>().Play("Walking_Color");
                        break;
                    default:
                        break;
                }
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
        if (!bad)
        {
            if (currentLifes < 0)
            {
                currentLifes = 0;
                gameManager.HandleLifes(true, currentLifes);
                //UpdateAnim();
            }
            else if (currentLifes >= maxLifes)
                currentLifes = maxLifes;
        }
        else
        {
            if (currentLifes <= -minLifes)
            {
                currentLifes = minLifes;
                //UpdateAnim();
                gameManager.HandleLifes(false, -currentLifes);
            }
            else if (currentLifes >= maxLifes)
            {
                currentLifes = maxLifes;
                //UpdateAnim();
                gameManager.HandleLifes(false, currentLifes);
            }
        }
        UpdateAnim();
    }

    public void Fall()
    {
        if (bad)
            gameObject.GetComponent<Animator>().Play("Fall_3-3");
        else
            gameObject.GetComponent<Animator>().Play("Fall_Animation");
    }

    private void UpdateAnim()
    {
        if (!bad)
        {
            if (currentLifes == maxLifes)
                animCont = 3;
            else
            {
                float aux = maxLifes / 3.0f;
                aux *= currentLifes;
                animCont = (int)aux;
            }
        }
        else if (bad && currentLifes > 0)
        {if (currentLifes == maxLifes)
                animCont = 3;
            else
            {
                float aux = minLifes / 3.0f;
                aux *= currentLifes;
                animCont = (int)aux;
            }
        }
        Debug.Log("V: " + currentLifes + "Anim: " + animCont);
    }
    public int LiveGetter() { return currentLifes; }
    public void LiveSetter(int _live) { currentLifes = _live; }
}
