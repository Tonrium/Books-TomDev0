using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIMgr.Instance.ShowPanel<MainLevelScene>(E_UILayer.Bottom);

        EventCenter.Instance.AddEventListener("TapNoteBook", () => UIMgr.Instance.ShowPanel<TestButton>(E_UILayer.Middle));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
