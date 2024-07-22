using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public List<Transform> waypoints;

    public GameObject wayPointsParent;

    public bool patrol = true;

    public Transform currentWaypoint;

    int currentWaypointIndex = 0;

    public float speed;

    public bool disturbed = false;

    public bool playerDead = false;


    private void OnEnable()
    {
        EventManager.onEnemyScare += Scare;
        EventManager.onPlayerDeath += onPlayerDeath;
        EventManager.onDamage += onAssassinated;
    }

    private void OnDisable()
    {
        EventManager.onEnemyScare -= Scare;
        EventManager.onPlayerDeath -= onPlayerDeath;
        EventManager.onDamage -= onAssassinated;
    }

    // Start is called before the first frame update
    void Start()
    {
        wayPointsParent = GameObject.Find("WayPoints_"+gameObject.name);
        if (wayPointsParent == null)
        {
            patrol = false;
        }
        else
        {
            int count = GetWayPoints();
            if (count == 0)
            {
                patrol = false;
            }
            else
            {
                currentWaypoint = waypoints[currentWaypointIndex];
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerDead)
        {
            if (patrol && !disturbed)
            {

                float distance = Vector3.Distance(transform.position, currentWaypoint.position);
                if (distance < 0.1f)
                {
                    currentWaypointIndex++;
                    if (currentWaypointIndex >= waypoints.Count)
                    {
                        currentWaypointIndex = 0;
                    }
                    currentWaypoint = waypoints[currentWaypointIndex];
                }
                Goto(currentWaypoint.position);
            }
            else if (!patrol && disturbed)
            {
                Goto(currentWaypoint.position);
            }
        }
    }

    public void Goto(Vector3 position)
    {
        transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);
        transform.right = position - transform.position;
    }

    public void Face(Vector3 pos)
    {
        transform.right = pos - transform.position;
    }

    public void Scare(List<GameObject> enemies, GameObject ptr)
    {
        if (enemies.Contains(gameObject))
        {
            currentWaypoint = ptr.transform;
            disturbed = true;
            patrol = false;
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

    public void onPlayerDeath()
    {
        playerDead = true;
        Face(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position);
        gameObject.GetComponent<FieldOfView>().playerDead = true;
    }

    public void onAssassinated(GameObject enemy)
    {
        if(enemy == gameObject)
        {
            gameObject.SetActive(false);
        }
    }

}
