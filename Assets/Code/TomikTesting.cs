
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomikTesting : MonoBehaviour {

    private Rigidbody2D rb;
    private float speed = 10f;


    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update() {
        if (Input.GetMouseButton(0)) {
            var mousepos = Input.mousePosition;
            mousepos.z = 10f;
            var pos = Camera.main.ScreenToWorldPoint(mousepos);
            Vector3 trajectory = ( pos- transform.position);
            trajectory.z = 0f;
            trajectory = trajectory.normalized * speed;
            Debug.Log("########## launch " + pos + " " + trajectory);
            rb.velocity = trajectory;
        }
    }
}