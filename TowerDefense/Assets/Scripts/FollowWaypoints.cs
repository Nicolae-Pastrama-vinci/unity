using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    public float speed = 1f;
    public int nextWaypoint = 1;
    public float distance = 0.1f;
    public List<GameObject> waypoints;

    public void SetFollowWaypoints(List<GameObject> waypoints)
    {
        this.waypoints = new List<GameObject> (waypoints);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (waypoints == null || waypoints.Count == 0) return;
        transform.position = waypoints[0].transform.position;
        transform.LookAt(waypoints[nextWaypoint].transform);
    }


    // Update is called once per frame
    void Update()
    {
        if(waypoints == null) return;
        if (nextWaypoint >= waypoints.Count) return;
        transform.position = Vector3.MoveTowards(transform.position, waypoints[nextWaypoint].transform.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, waypoints[nextWaypoint].transform.position) < distance)
        {
            nextWaypoint++;
            if (nextWaypoint >= waypoints.Count)
            {
                Destroy(this.transform.gameObject);
            }
            else
            {
                transform.LookAt(waypoints[nextWaypoint].transform);
            }
        }
        
        
    }
}
