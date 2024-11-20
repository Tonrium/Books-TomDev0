using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class You : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        EventCenter.Instance.AddEventListener("MonsterDead", YouWin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void YouWin()
    {
        print("win");
    }
}
