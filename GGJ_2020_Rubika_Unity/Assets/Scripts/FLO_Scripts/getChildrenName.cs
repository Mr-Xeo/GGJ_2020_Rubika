using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getChildrenName : MonoBehaviour
{

    public static string goChildName;

    void Update()
    {
        if (this.gameObject.transform.childCount > 0)
        {
             goChildName = this.gameObject.transform.GetChild(0).name;
        }
    }
}
