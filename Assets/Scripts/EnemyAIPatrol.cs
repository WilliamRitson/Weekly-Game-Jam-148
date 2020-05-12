using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIPatrol : Controller
{
    public float speed;
    public Transform[] waypoints;
    public float waitTime;




    private float startWaitTime;
    private int randomWaypoint;



    private void Start()
    {
        randomWaypoint = Random.Range(0, waypoints.Length);
        startWaitTime = waitTime;
    }


    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[randomWaypoint].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position,waypoints[randomWaypoint].position)<0.2f)
        {
            if(waitTime<=0)
            {
                randomWaypoint = Random.Range(0, waypoints.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

}
