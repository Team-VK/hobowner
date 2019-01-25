
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomikTesting : MonoBehaviour {


    private Vector3 mousePosition;
    private Vector2 direction;
    private float moveSpeed = 1f;
    private bool mouseDown = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            mouseDown = true;
            Debug.Log("##########1 " + Input.mousePosition);
            var pos = Input.mousePosition;
        pos.z = 10;
        pos = Camera.main.ScreenToWorldPoint(pos);
        transform.position = pos;
            Debug.Log("##########2 " + transform.position);
        }
    }
     /*
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mousePosition);
            direction = (mousePosition - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePosition - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
        }

        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    */
}