using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public List<Transform> waypoints;
    public float speed;
    int waypointIndex;
    Transform currentWaypoint;
    bool moving = false;
    Animator animator;

    Rigidbody2D rb;

    void Start()
    {
       waypointIndex = 0; 
       rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(!moving){
            StartBoat();
        }
        if(currentWaypoint != null && moving){
            GotoWaypoint();
        }
    }

    void GotoWaypoint(){
        Vector3 direction = Vector3.Normalize(currentWaypoint.transform.position - transform.position);
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        if(IsOnWaypoint()){
            Debug.Log("here");
            waypointIndex++;
            StartBoat();
        }
    }
    
    bool IsOnWaypoint(){
        Debug.Log(Vector3.Distance(currentWaypoint.transform.position, transform.position));
        return Vector3.Distance(currentWaypoint.transform.position, transform.position) <= 0.1f;
    }

    void StartBoat(){
        if(waypoints.Count <= waypointIndex){
            waypointIndex = 0;
        }
        currentWaypoint = waypoints[waypointIndex];
        moving = true;
    }
}
