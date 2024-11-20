using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dead();
    }

    void Dead()
    {
        print("dead");
        EventCenter.Instance.EventTrigger("MonsterDead");
    }
}
