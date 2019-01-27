
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour {

    // public variables for this object, edit from Unity menu 
    public int availablePoints = 40;
    public float pointDecayInterval = 0.2f;
    public float zHack = 10f;

    // private fields for this object
    private Rigidbody rb;
    private float draggingSpeed = 10f;
    private bool dragging = false;
    private float currentPointDecayInterval;
    public static Camera camera;

    // a flag for checking if any objects of this type is being dragged
    private static bool isDraggingSomeOneElse = false;


    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        currentPointDecayInterval = pointDecayInterval;
        camera = Camera.main;
    }

    // Update is called once per frame

    void Update() {
        if (Input.GetMouseButton(0)) {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
 
            if ((Physics.Raycast(ray, out hit) && hit.rigidbody == rb && !isDraggingSomeOneElse) || dragging) {
        
                // If object enters dragging mode - add points (if any) and set objects available points to 0
                if (dragging == false) {
                    Score.score += availablePoints;
                    availablePoints = 0;
                }   
                // Set dragging flags as true
                dragging = true;
                isDraggingSomeOneElse = true;

                // Determine input position, calculate the difference between camera and this.obj depth
                Vector3 inputpos = Input.mousePosition;
                inputpos.z = transform.position.z - (Camera.main.gameObject.transform.position.z);

                // Get the mouse pointers target position
                Vector3 targetPos = Camera.main.ScreenToWorldPoint(inputpos);
                // Calculate direction and speed for this.obj and mouse target position
                Vector3 trajectory = (targetPos - transform.position);
                float distance = Vector3.Distance (targetPos, transform.position);
                trajectory = trajectory.normalized * draggingSpeed * distance;
                // Move the object in the mouse direction
                rb.velocity = trajectory;
                // Stop spinnig
                rb.angularVelocity = Vector3.zero;
            }
        }
        else {
            // If mouse one is not pressed, remove dragging flags
            dragging = false;
            isDraggingSomeOneElse = false;
        }

        // Decay available points on this object
        decayPoints();
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
