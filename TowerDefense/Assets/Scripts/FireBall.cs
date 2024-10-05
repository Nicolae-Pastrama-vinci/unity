using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{ 
    public GameObject target { get; set; }
    public int damage = 45;
    private float speed = 4f;
    public Transform firePoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ennemy"))
        {
            other.gameObject.GetComponent<HealthPoints>().SetHp(damage);
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        transform.position = firePoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

    }
}
