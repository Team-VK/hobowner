using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private float gametimer = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse X") < 0)
        {
            //Code for action on mouse moving left
            print("Mouse moved left");
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            //Code for action on mouse moving right
            print("Mouse moved right");
        }
        if (Input.GetAxis("Mouse Y") < 0)
        {
            //Code for action on mouse moving left
            print("Mouse moved down");
        }
        if (Input.GetAxis("Mouse Y") > 0)
        {
            //Code for action on mouse moving right
            print("Mouse moved up");
        }
    }
}