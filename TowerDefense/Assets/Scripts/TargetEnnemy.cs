using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnnemy : MonoBehaviour
{
    List<GameObject> targets  = new List<GameObject>();
    public Transform crystal;
    bool coroutineIsRuning = false;

    private void Start()
    {
        coroutineIsRuning=true;
        StartCoroutine(ShotTheEnnemy());
        StartCoroutine(LookAtEnnemy());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ennemy")
        {
            targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "ennemy")
        {
            targets.Remove(other.gameObject);
        }
    }

    public IEnumerator ShotTheEnnemy()
    {
        while(coroutineIsRuning)
        {
            if (targets.Count > 0)
            {
                targets[0].GetComponent<HealthPoints>().hp -= 100;
                yield return new WaitForSeconds(1);
            }
        }
        
        yield return null;
    }

    public IEnumerator LookAtEnnemy()
    {
        while (coroutineIsRuning)
        {
            if (targets.Count > 0)
            {
                transform.Rotate(targets[0].transform.position);
            }
            
        }
        yield return null;

    }
}
