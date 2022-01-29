using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSwitch : MonoBehaviour
{
    [SerializeField]
    private float speed=2;
    [SerializeField]
    private Image []  backgrounds = new Image[2];
    private bool happy = true;

    // Start is called before the first frame update
    void Start()
    {
        backgrounds[0].enabled = happy;
        backgrounds[1].enabled = !happy;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ChangeBackground();

    }
    //private void LateUpdate()
    //{
    //    backgrounds[0].color = new Color(backgrounds[0].color.r, backgrounds[0].color.g, backgrounds[0].color.b, Mathf.Lerp(backgrounds[0].color.a, 0, Time.deltaTime * speed));
    //    backgrounds[0].color = new Color(backgrounds[0].color.r, backgrounds[0].color.g, backgrounds[0].color.b, Mathf.Lerp(backgrounds[0].color.a, 0, Time.deltaTime * speed));
    //}
    public void ChangeBackground()
    {
        happy = !happy;
        backgrounds[0].enabled = happy;
        backgrounds[1].enabled = !happy;
    }
}
