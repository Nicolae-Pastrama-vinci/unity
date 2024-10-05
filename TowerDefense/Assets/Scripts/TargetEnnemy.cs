using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TargetEnnemy : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();
    public bool coroutineIsRuning = false;
    public Transform firePoint;
    public LineRenderer laser;
    public float fireRate = 0.5f;
    public GameObject fireBall;
    public List<GameObject> fireBalls = new List<GameObject> ();

    private void Start()
    {
        coroutineIsRuning = true;
        StartCoroutine(ShotTheEnnemy());
        StartCoroutine(LookAtEnnemy());
        laser.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ennemy"))
        {
            if (!targets.Contains(other.gameObject)) // Assure que l'ennemi n'est pas déjà dans la liste
            {
                targets.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ennemy"))
        {
            if (targets.Contains(other.gameObject))
            {
                targets.Remove(other.gameObject);
                laser.enabled = false;


            }
        }
    }

    void Laser()
    {
        laser.enabled = true;
        laser.SetPosition(0, firePoint.position);
        laser.SetPosition(1, targets[0].transform.position);
    }

    public IEnumerator ShotTheEnnemy()
    {
        while (coroutineIsRuning)
        {
            if (targets.Count > 0)
            {
                // Vérifie que le premier ennemi de la liste est encore valide et actif
                if (targets[0] != null)
                {
                    HealthPoints hp = targets[0].GetComponent<HealthPoints>();
                    if (hp != null)
                    {
                        GameObject ball = Instantiate(fireBall);
                        ball.GetComponent<FireBall>().target = targets[0];
                        fireBalls.Add(ball);
                    }
                }
                yield return new WaitForSeconds(fireRate);
            }
            else
            {
                yield return null;
            }
        }
    }

    public IEnumerator LookAtEnnemy()
    {
        while (coroutineIsRuning)
        {
            if (targets.Count > 0)
            {
                if (targets[0] != null && targets[0].activeInHierarchy) // Vérifie que la cible est valide
                { 
                    Laser();
                    Vector3 lookDir = targets[0].transform.position - transform.position;
                    lookDir.y = 0; // keep only the horizontal direction
                    transform.rotation = Quaternion.LookRotation(lookDir);
                }
                else
                {
                    laser.enabled = false;
                    // Retire l'ennemi de la liste si invalide
                    targets.RemoveAt(0);
                    foreach (GameObject b in fireBalls)
                    {
                        Destroy(b);
                    }
                }
            }
            yield return null;
        }
    }
}
