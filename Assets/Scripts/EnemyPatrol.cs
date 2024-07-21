using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public List<Transform> waypoints;

    public GameObject wayPointsParent;

    public bool patrol = true;

    Transform currentWaypoint;

    int currentWaypointIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("WayPoints_"+gameObject.name);
        wayPointsParent = GameObject.Find("WayPoints_"+gameObject.name).gameObject;
        int count = GetWayPoints();
        if(count == 0)
        {
            patrol = false;
        }
        else
        {
            currentWaypoint = waypoints[currentWaypointIndex];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (patrol)
        {
            
            float distance = Vector3.Distance(transform.position, currentWaypoint.position);
            if (distance < 0.1f)
            {
                currentWaypointIndex++;
                if(currentWaypointIndex >= waypoints.Count)
                {
                    currentWaypointIndex = 0;
                }
                currentWaypoint = waypoints[currentWaypointIndex];
            }
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, Time.deltaTime);
            transform.right = currentWaypoint.position - transform.position;
        }
    }

    public int GetWayPoints()
    {
        if(wayPointsParent.transform.childCount == 0)
        {
            return 0;
        }
        for(int i = 0; i < wayPointsParent.transform.childCount; i++)
        {
            waypoints.Add(wayPointsParent.transform.GetChild(i));
        }
        return waypoints.Count;
    }

}
