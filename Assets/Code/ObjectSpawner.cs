using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    //public static Transform box;
    //public static Transform board;
    //public static Transform shoe;
    //public static Transform cat;
    //public static Transform fpan;
    //public static Transform bottle;
    //public static Transform bomb;
    //public static Transform tv;
    //public static Transform cone;
    public GameObject cube;

    private float time = 0f;

    // Use this for initialization
    void Start () {
    }
    
    // Update is called once per frame
    void Update () {
        // Odds of spawning a new obstacle increses as the game goes on

        int side_rng = Random.Range(0, 2);
        float angle_rng = 0f;
        int velocity_rng = Random.Range(5, 20);
        int object_rng = Random.Range(0,9);
        float spawnheight_rng = Random.Range(10f, 90f); //todo: sensible values for y coordinate of spawned objects

        time += Time.deltaTime / 100f;  //* (float) GameStatus.score;
        float rnd = Random.Range(0f, 1f);
        if (time > rnd) {
            spawnObjectInstance(side_rng, angle_rng, velocity_rng, object_rng, spawnheight_rng);
            time = 0f;
        }
    }

    private void spawnObjectInstance(int side_rng, float angle_rng, int velocity_rng, int object_rng, float spawnheight_rng) {

        //Transform[] objects = new[] {box, board, shoe, cat, fpan, bottle, bomb, tv, cone};
        //Transform[] objects = new[] { Cube, Cube, Cube, Cube, Cube, Cube, Cube, Cube, Cube };

        //Debug.Log("side rng: " + side_rng);
        float spawnx = 0;
        float spawny = spawnheight_rng;

        if(side_rng >= 1) {
            spawnx = -280; //todo: sensible value for left side
            angle_rng = Random.Range(270f, 359f);
        }
        else
        {
            spawnx = 280; //todo: sensible value for right side
            angle_rng = Random.Range(0f, 90f);
        }
        
        Vector3 mainhobo = GameObject.FindGameObjectWithTag("mainhobo").transform.position;
        var pos = Camera.main.ViewportToWorldPoint(mainhobo);

        pos.x = spawnx;
        pos.y = spawny;

        //Debug.Log("Randomed spawn points after worldtoviewportpoint: " + pos.x + "," + spawny);

        //print(objects[object_rng]);
        GameObject spawnedobject = Instantiate(cube, (new Vector3(pos.x, pos.y, 0f)), Quaternion.identity);
        //Debug.Log("World pos: " + spawnedobject.transform.position);
        Debug.Log("Angle:" + angle_rng);

        Vector3 dir;

        Debug.Log("#####");
        if (angle_rng >= 270) {
            dir = Quaternion.AngleAxis(angle_rng, transform.TransformPoint(new Vector3(10,10,0))) * transform.TransformPoint((new Vector3(10,0,0)));
            Debug.Log("Should fly LEFT");
        }
        else
        {
            dir = Quaternion.AngleAxis(angle_rng, transform.TransformPoint(new Vector3(-10, 10, 0))) * transform.TransformPoint(new Vector3(-10, 0, 0));
            Debug.Log("Should fly RIGHT");
        }


        Vector3 transDir = dir;
        //Vector3 transDir = transform.TransformPoint(dir);
        spawnedobject.GetComponent<Rigidbody>().AddForce(transDir * velocity_rng);


        Debug.Log("Velocity: " + velocity_rng);
        Debug.Log("Direction vector: " + transDir);
        Debug.Log("#####");

    }
}