using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoboCollisionBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        Rigidbody collidingObject = col.rigidbody;
        if (collidingObject.gameObject.name == "raindrop(Clone)")
        {
            Score.score -= 10;
            Destroy(collidingObject.gameObject);
        }

    }
}
