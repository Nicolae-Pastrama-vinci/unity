using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnnemies : MonoBehaviour
{
    public List<GameObject> mobs;
    public float interval = 3f;
    public float timer = 0f;
    public List<GameObject> waypoints;


    private void Start()
    {
        SpawnMob();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= interval)
        {
            timer = 0f;
            SpawnMob();
        }
    }

    public void SpawnMob()
    {
        int id = Random.Range(0, mobs.Count);
        GameObject mob = Instantiate(mobs[id]);
        if (mob.GetComponent<FollowWaypoints>() != null)
        {
            mob.transform.localScale = new Vector3(15,15,15);
            mob.GetComponent<FollowWaypoints>().setFollowWaypoints(waypoints);
            mob.GetComponent<FollowWaypoints>().enabled = true;
        }
        
    }
}
