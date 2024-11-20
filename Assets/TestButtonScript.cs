using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtonScript : BasePanel
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(string item in controlDic.Keys)
        {
            print(item);
        }
    }

    protected override void ClickBtn(string btnName)
    {
        switch (btnName)
        {
            case "TestButton":
                print("btnNameTest");
                break;
        }
    }

    public override void ShowMe()
    {

    }
    public override void HideMe()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
