using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public int hp;


    public int GetHp() { return hp; }

    public void SetHp(int hp)
    {
        this.hp -= hp;
        if (this.hp <= 0)
        {
            Destroy(this.transform.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
    }
}
