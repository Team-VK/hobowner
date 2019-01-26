
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomikTesting : MonoBehaviour {

    // public variables for this object, edit from Unity menu 
    public int availablePoints = 40;
    public float pointDecayInterval = 0.2f;
    public float zHack = 10f;

    // private fields for this object
    private Rigidbody rb;
    private float draggingSpeed = 10f;
    private float grabDistance = 1.5f;
    private bool dragging = false;
    private float currentPointDecayInterval;

    // a flag for checking if any objects of this type is being dragged
    private static bool isDraggingSomeOneElse = false;


    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        currentPointDecayInterval = pointDecayInterval;
    }

    // Update is called once per frame

    void Update() {
        if (Input.GetMouseButton(0)) {
            var mousepos = Input.mousePosition;
            mousepos.z = zHack;
            var pos = Camera.main.ScreenToWorldPoint(mousepos);
            float distance = Vector3.Distance (pos, transform.position);
            // Check if this object is in grabbing range and there is no other objects being dragged
            // If this object is in dragging -> enter if and update trajectory
            if ((distance < grabDistance && !isDraggingSomeOneElse) || dragging) {
                // If object enters dragging mode - add points (if any) and set objects available points to 0
                if (dragging == false) {
                    Score.score += availablePoints;
                    availablePoints = 0;
                    Debug.Log("########## " + Score.score);
                }
                // Move object towards mouse - the longer the distance, the faster it moves
                dragging = true;
                isDraggingSomeOneElse = true;
                Vector3 trajectory = (pos - transform.position);
                trajectory.z = 0f;
                trajectory = trajectory.normalized * draggingSpeed * distance;
                rb.velocity = trajectory;
            }
        }
        else {
            // If mouse one is not pressed, remove dragging flags
            dragging = false;
            isDraggingSomeOneElse = false;
        }

        // Decay available points on this object
        decayPoints();

        // Keep object in z axis
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void decayPoints() {
        currentPointDecayInterval -= Time.deltaTime;
        if (currentPointDecayInterval < 0) {
            availablePoints = availablePoints-1;
            if (availablePoints < 0) {
                availablePoints = 0;
            }
            currentPointDecayInterval = pointDecayInterval; 
        }
        //Debug.Log("########## score decaying  " + currentPointDecayInterval + " " + availablePoints + " " + Time.deltaTime);

    }


    // Ic a bomb explodes, it iterates all instances of this class and calls this method
    // This method will apply correct force on this object FROM the bomb explosion
    public void Exploder(float explosionForce, Vector3 position, float explosionRadius, float upwardsModifier, ForceMode mode) {
        rb.AddExplosionForce(explosionForce, position, explosionRadius, upwardsModifier, mode);
    }
}
