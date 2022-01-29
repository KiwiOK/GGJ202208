using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float transitionSpeed = 1;
    private Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = transform.position;
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
