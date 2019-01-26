﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public static Transform box;
    public static Transform board;
    public static Transform shoe;
    public static Transform cat;
    public static Transform fpan;
    public static Transform bottle;
    public static Transform bomb;
    public static Transform tv;
    public static Transform cone;

    private float time = 0f;

    // Use this for initialization
    void Start () {
    }
    
    // Update is called once per frame
    void Update () {
        // Odds of spawning a new obstacle increses as the game goes on

        int side_rng = Random.Range(0, 1);
        int angle_rng = Random.Range(0, 90); //todo: add sensible values based on which side the object spawns in
        int velocity_rng = Random.Range(5, 20);
        int object_rng = Random.Range(0,8);
        int spawnheight_rng = Random.Range(0, 90); //todo: sensible values for y coordinate of spawned objects

        time += Time.deltaTime / 10000f;  //* (float) GameStatus.score;
        float rnd = Random.Range(0f, 1f);
        if (time > rnd) {
            spawnObjectInstance(side_rng, angle_rng, velocity_rng, object_rng, spawnheight_rng);
            time = 0f;
        }
    }

    private void spawnObjectInstance(int side_rng, int angle_rng, int velocity_rng, int object_rng, int spawnheight_rng) {

        Transform[] objects = new[] {box, board, shoe, cat, fpan, bottle, bomb, tv, cone};

        float spawnx = 0.0f;
        float spawny = 0.0f;

        if(side_rng > 1) {
            spawnx = 90; //todo: sensible value for left side
        }
        else
        {
            spawnx = 180; //todo: sensible value for right side
        }

        Vector3 mainhobo = GameObject.FindGameObjectWithTag("mainhobo").transform.position;
        var pos = Camera.main.WorldToViewportPoint(mainhobo);
        pos.x = spawnx;
        pos.y = spawny;

        Object spawnedobject = Instantiate(objects[object_rng], Camera.main.ViewportToWorldPoint(new Vector3(pos.x, pos.y, 0f)), Quaternion.identity);

        Vector3 dir = Quaternion.AngleAxis(angle_rng, Vector3.forward) * Vector3.right;
        //spawnedobject.GetComponent<Rigidbody2D>().AddForce(dir * velocity_rng);


        }
    }

}