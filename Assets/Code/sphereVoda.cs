using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereVoda : MonoBehaviour {

    //public static Transform box;
    //public static Transform board;
    //public static Transform shoe;
    //public static Transform cat;
    //public static Transform fpan;
    //public static Transform bottle;
    //public static Transform bomb;
    //public static Transform tv;
    //public static Transform cone;
    public GameObject raindrop;
    public Queue<GameObject> drops;

    private float time = 0f;

    // Use this for initialization
    void Start () {
        drops = new Queue<GameObject>();
    }

    // Update is called once per frame
    void Update () {
        Debug.Log("Update");

        time += Time.deltaTime / 100f;  //* (float) GameStatus.score;
        float rnd = Random.Range(0f, 1f);
        if (time > rnd)
        {
            spawnRaindrop();
            time = 0f;
        }


        if(drops.Count > 700) { 
            GameObject dequeuedobject = drops.Dequeue();
            Destroy(dequeuedobject);
            Debug.Log("Destroyed raindrop");
        }
    }

    private void spawnRaindrop() {
        float spawny = 200f;
        float spawnx = Random.Range(-150, 150);
        float spawnz = -270f;
        GameObject spawnedobject = Instantiate(raindrop, (new Vector3(spawnx, spawny, spawnz)), Quaternion.identity);
        drops.Enqueue(spawnedobject);
    }

}