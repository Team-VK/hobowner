
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomikTesting : MonoBehaviour {

    private Rigidbody2D rb;
    private float draggingSpeed = 10f;
    private float grabDistance = 1.5f;
    private float zHack = 10f;


    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update() {
        if (Input.GetMouseButton(0)) {
            var mousepos = Input.mousePosition;
            mousepos.z = zHack;
            var pos = Camera.main.ScreenToWorldPoint(mousepos);
            float distance = Vector3.Distance (pos, transform.position);
            // Check if this object is in grabbing range
            if (distance < grabDistance) {
                Vector3 trajectory = ( pos- transform.position);
                trajectory.z = 0f;
                trajectory = trajectory.normalized * draggingSpeed * distance;
                rb.velocity = trajectory;
            }
        }
    }
}