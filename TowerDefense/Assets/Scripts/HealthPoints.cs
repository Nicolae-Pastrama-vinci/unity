using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public int hp
    {
        get { return hp; }
        set
        {
            hp = value;
            if(hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
    }
}
