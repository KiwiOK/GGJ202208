using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private Vector3 topVector = new Vector3(0, 1, 0);
    private bool move, arrived;
    [SerializeField]
    private float transitionSpeed = 1;
    private Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            ChangeScenario();
                //transform.position = new Vector3(transform.position.x, transform.position.y * -1, transform.position.z);
    }

    private void LateUpdate()
    {
            transform.position = Vector3.Lerp(transform.position, nextPos, Time.deltaTime*transitionSpeed);
            if (transform.position.y<0)
                transform.LookAt(target.transform, Vector3.down);
            else
                transform.LookAt(target.transform, Vector3.up);

    }

    public void ChangeScenario()
    {
            nextPos = new Vector3(transform.position.x, transform.position.y * -1, transform.position.z);
    }
}
