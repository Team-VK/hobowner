
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomikTesting : MonoBehaviour {

    private Rigidbody rb;
    private float draggingSpeed = 10f;
    private float grabDistance = 1.5f;
    private float zHack = 10f;
    private bool dragging = false;


    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void Update() {
        if (Input.GetMouseButton(0)) {
            var mousepos = Input.mousePosition;
            mousepos.z = zHack;
            var pos = Camera.main.ScreenToWorldPoint(mousepos);
            float distance = Vector3.Distance (pos, transform.position);
            // Check if this object is in grabbing range
            if (distance < grabDistance || dragging) {
                dragging = true;
                Vector3 trajectory = (pos - transform.position);
                trajectory.z = 0f;
                trajectory = trajectory.normalized * draggingSpeed * distance;
                rb.velocity = trajectory;
            }
        }
        else {
            dragging = false;
        }
    }


    public void Exploder(float explosionForce, Vector3 position, float explosionRadius, float upwardsModifier, ForceMode mode) {

        rb.AddExplosionForce(explosionForce, position, explosionRadius, upwardsModifier, mode);
    }
}
