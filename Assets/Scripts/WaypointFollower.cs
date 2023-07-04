using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;
    [SerializeField] float speed = 1f;
    void Update()
    {
        if(Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < 0.1f){ //exact 0 is not taken due to imprecision
            currentWaypointIndex++;
            if(currentWaypointIndex>=waypoints.Length){
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
        //move from current position[transform.position] --> position of the first wavepoint, 
        //in (speed * Time.deltaTime) magnitute of velocity
        // Time.deltaTime = time elapsed since the last frame
        // it is used to make the movement frame rate independent, ensuring consistent speed regradless of frame rate
        // Time.deltaTime = 1/fps, which ensures constant (units/frame) as well as constant (units/sec)
    }
}
