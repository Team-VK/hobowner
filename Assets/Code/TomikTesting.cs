
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomikTesting : MonoBehaviour {


    private Vector3 mousePosition;
    private Vector2 direction;
    private bool mouseDown = false;
    private Vector3 lastpos;
    private Rigidbody2D rb;
    private float speed = 10f;


    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update() {
        if (Input.GetMouseButton(0)) {
            mouseDown = true;
            //Debug.Log("##########1 " + Input.mousePosition);
            var pos = Input.mousePosition;
            pos.z = 500;
            pos = Camera.main.ScreenToWorldPoint(pos);
            transform.position = pos;
            Debug.Log("##########2 " + transform.position);
            lastpos = pos;
            rb.velocity = Vector2.zero;
        }
        else if (mouseDown == true) {
            var mousepos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseDown = false;
            Vector3 trajectory = ( mousepos- lastpos);
            trajectory.z = 0f;
            trajectory = trajectory.normalized * speed;
            Debug.Log("########## launch " + mousepos + " " + lastpos + " " + trajectory);
            rb.velocity = trajectory;
        }
    }
}