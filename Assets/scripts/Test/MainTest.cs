using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIMgr.Instance.ShowPanel<TestButton>(E_UILayer.Middle, (panel) =>
        {
            panel.test();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
