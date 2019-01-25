using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class PlayerInput : MonoBehaviour
{

    private float gametimer = 0;
    private float x;
    private float y;

    // Use this for initialization
    void Start()
    {
        print("Whut?");
        this.x = 0f;
        this.y = 0f;

    }

    // Update is called once per frame
    void Update() {
        var crosshairspeed = 3.0f;

        print("Im currently at: " + this.x + "," + this.y);

        //Crosshair controls
        if (this.CompareTag ("Pointer") == true) {
            if (Input.GetAxis("Mouse X") < 0) {
            //Code for action on mouse moving left
            print("Mouse moved left");
            Debug.Log (this.transform.position.x * Time.deltaTime);
            this.x -= crosshairspeed * Time.deltaTime;
            }
            if (Input.GetAxis("Mouse X") > 0) {
                //Code for action on mouse moving right
                print("Mouse moved right");
                Debug.Log (this.transform.position.x * Time.deltaTime);
                this.x += crosshairspeed * Time.deltaTime;
            }
            if (Input.GetAxis("Mouse Y") < 0) {
                print("Mouse moved down");
                Debug.Log (this.transform.position.y * Time.deltaTime);
                this.y -= crosshairspeed * Time.deltaTime;
            }
            if (Input.GetAxis("Mouse Y") > 0) {
                print("Mouse moved up");
                Debug.Log (this.transform.position.y * Time.deltaTime);
                this.y += crosshairspeed * Time.deltaTime;
            }
        }    

        if (Input.GetKey ("escape")) {
                Application.Quit();
        }
    }
}